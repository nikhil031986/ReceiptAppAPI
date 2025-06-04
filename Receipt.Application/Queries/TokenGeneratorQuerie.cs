using MediatR;
using Receipt.Domain.Common;
using Receipt.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace Receipt.Application.Queries
{
    public record TokenGeneratorQuerie(string emailId, string password) : 
        IRequest<BaseResponse<AuthenticationResponse>>;

    internal class TokenGeneratorQuerieHandler(ITokenGenerator tokenGenerator)
        : IRequestHandler<TokenGeneratorQuerie, BaseResponse<AuthenticationResponse>>
    {
        public async Task<BaseResponse<AuthenticationResponse>> Handle(TokenGeneratorQuerie request, CancellationToken cancellationToken)
        {
            return await tokenGenerator.Login(request.emailId, request.password);
        }
    }

    public record LogoutQuerie(string token):
        IRequest<bool>;

    internal class LogoutQuerieHandler(ITokenGenerator tokenGenerator)
        : IRequestHandler<LogoutQuerie, bool> 
    {
        public Task<bool> Handle(LogoutQuerie request, CancellationToken cancellationToken)
        {
            return tokenGenerator.Logout(request.token);
        }
       
    }

    public record TokenValidQuerie(string token) :
        IRequest<bool>;

    internal class TokenValidQuerieHandler(ITokenGenerator tokenGenerator)
        : IRequestHandler<TokenValidQuerie, bool>
    {
        public Task<bool> Handle(TokenValidQuerie request, CancellationToken cancellationToken)
        {
            return tokenGenerator.tokenValid(request.token);
        }

    }
}
