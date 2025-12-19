using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using Microsoft.IdentityModel.Tokens;
using Receipt.Domain.Common;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using Receipt.Infra.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Infra.Repositories
{
    public class TokenGenerator(AppDbContext appDbContext) : ITokenGenerator
    {
        private HashSet<string> logoutToken = new HashSet<string>();
        private readonly string jwtKey = "84322CFB66934ECC86D547C5CF4F2EFC";
        private readonly string jwtIssuer = "ReceiptApplication";
        private readonly string Audience = "ReceiptAppAutho";
        private readonly int DurationInMinutes = 60;
        
        public async Task<BaseResponse<AuthenticationResponse>> Login(string userEmailId, string password)
        {
            var user = await appDbContext.userMasters.SingleOrDefaultAsync(x => 
                                x.EmailId.Equals(userEmailId) &&
                                x.Password.Equals(password));
            if (user == null)
            {
                return null;
            }
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse authenticationResponse = new AuthenticationResponse();
            authenticationResponse.Id = Convert.ToString(user.UserId);
            authenticationResponse.JWToken =new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationResponse.Email = user.EmailId;
            authenticationResponse.UserName = user.UserName;
            authenticationResponse.Roles = new List<string> { "Admin" };
            authenticationResponse.IsVerified = true;
            authenticationResponse.RefreshToken = "Token";
            return new BaseResponse<AuthenticationResponse>(authenticationResponse, $"Authenticated {user.UserName}");
        }

        public async Task<bool> Logout(string token)
        {
            this.logoutToken.Add(token);
            return true;
        }

        public async Task<bool> tokenValid(string token)
        {
            return this.logoutToken.Contains(token);
        }

        private async Task<JwtSecurityToken> GenerateJWToken(UserMaster user)
        {

            var roleClaims = new List<Claim>();


            string ipAddress = "";

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.EmailId),
                new Claim("uid", user.UserId.ToString()),
                new Claim("ip", ipAddress),
                new Claim(ClaimTypes.Role,(user.IsAdmin==true?"Admin":"Client"))

            }
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: this.jwtIssuer,
                audience: this.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(this.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

    }
}
