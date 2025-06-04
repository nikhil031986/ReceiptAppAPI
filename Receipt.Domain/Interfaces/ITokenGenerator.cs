using Receipt.Domain.Common;

namespace Receipt.Domain.Interfaces
{
    public interface ITokenGenerator
    {
        Task<BaseResponse<AuthenticationResponse>> Login(string userEmailId, string password);
        Task<bool> Logout(string token);
        Task<bool> tokenValid(string token);
    }
}
