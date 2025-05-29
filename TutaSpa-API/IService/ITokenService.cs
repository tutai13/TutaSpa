using Azure.Core;
using TutaSpa_API.DTOs.Auth;
using TutaSpa_API.Models;

namespace TutaSpa_API.IService
{
    public interface ITokenService
    {
        public Task<TokenDTO> GenerateToken(User user , IList<string> Roles);
        public TokenDTO GenerateChangePasswordToken(User user );
        public Task<RefreshToken?> CheckFreshToken(string freshToken);


        public Task RevokeToken(string Token); 

    }
}
