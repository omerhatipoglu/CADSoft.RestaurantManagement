using CADSoft.Api.Web.Attributes;
using CADSoft.Entity.Models.Response;
using System.Web.Http;

namespace CADSoft.Api.Web.Controllers
{
    [AuthenticateUser]
    public class TestController : ApiController
    {
        [HttpPost]
        public BaseResponse<string> Test()
        {
            return new BaseResponse<string>("true");
        }
    }
}
