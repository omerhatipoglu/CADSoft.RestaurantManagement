using CADSoft.Entity.Models.Request;
using CADSoft.Entity.Models.Response;

namespace CADSoft.BL.Abstract
{
    public interface IAuthenticateBL
    {
        BaseResponse<AuthenticationResponse> Login(AuthenticationRequest request);
        void ValidetaAuthenticationHeader(string header);
        void ValidateToken(string token);
    }
}
