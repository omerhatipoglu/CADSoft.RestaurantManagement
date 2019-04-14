using CADSoft.BL.Abstract;
using CADSoft.BL.Concrete;
using CADSoft.Entity.Models.Request;
using CADSoft.Entity.Models.Response;
using System.Web.Http;

namespace CADSoft.Api.Web.Controllers
{
    public class AuthenticateController : ApiController
    {
        IAuthenticateBL _IAuthenticateBL;
        public AuthenticateController()
        {
            _IAuthenticateBL = new AuthenticateBL();
        }
        [HttpPost]
        public BaseResponse<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            return _IAuthenticateBL.Login(request);
        }
    }
}
