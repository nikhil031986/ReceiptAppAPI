using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Receipt.API;
using Receipt.Application.Commands;
using System.Net;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration["ApiKey"] = "C10D6AB6-8CBF-45F9-A5C2-4769CE171DF9";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOriginPolicy",
        policy => policy
            .WithOrigins("http://localhost:4200/*") 
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
    );
});

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:jwtIssuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:jwtKey"].ToString())),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("AtLeastTwoRoles", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", ClaimTypes.Role, "Client"));
    options.AddPolicy("Admin", policy =>
       policy.RequireRole("Admin"));

    options.AddPolicy("Client", policy =>
    policy.RequireClaim("Client", "Client"));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAppDI();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ReceiptAPPV1",
        Version = "v1"
    });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Enter API Key into the field",
        Name = "X-API-KEY",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                Scheme = "ApiKeyScheme",
                Name = "X-API-KEY",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});



var app = builder.Build();

app.UseRouting();

app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

// API key middleware — insert after app.UseCors(...) and before app.UseAuthentication()
app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value?.ToLowerInvariant() ?? string.Empty;

    // Allow Swagger UI and assets in Development (RoutePrefix = "")
    if (app.Environment.IsDevelopment())
    {
        if (path == "/"
            || path.StartsWith("/swagger")
            || path.StartsWith("/swagger-ui")
            || path.StartsWith("/swagger/v1/swagger.json")
            || path.StartsWith("/favicon.ico"))
        {
            await next();
            return;
        }
    }

    // List of public endpoints that should NOT require the API key (lowercase)
    var publicPaths = new[]
    {
        "/api/usermaster/login", // allow login without X-API-KEY so clients can request tokens
        // add other public endpoints here (e.g. "/health", "/api/public/...") as needed
    };

    if (publicPaths.Any(p => path.StartsWith(p)))
    {
        await next();
        return;
    }

    var configApiKey = builder.Configuration["ApiKey"];
    if (string.IsNullOrWhiteSpace(configApiKey))
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync("API key not configured.");
        return;
    }

    if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKeyValues)
        || string.IsNullOrWhiteSpace(extractedApiKeyValues.ToString()))
    {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        await context.Response.WriteAsync("API Key missing.");
        return;
    }

    var extractedApiKey = extractedApiKeyValues.ToString();
    if (!string.Equals(extractedApiKey, configApiKey, StringComparison.Ordinal))
    {
        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        await context.Response.WriteAsync("Invalid API Key.");
        return;
    }

    await next();
});

app.UseAuthentication();

app.UseAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Receipt Application API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();



app.MapControllers();




app.Run();
