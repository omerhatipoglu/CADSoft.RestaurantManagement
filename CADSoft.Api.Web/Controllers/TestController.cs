using CADSoft.BL.Abstract;
using CADSoft.BL.Concrete;
using CADSoft.Entity.Models.Response;
using System.Web.Http;

namespace CADSoft.Api.Web.Controllers
{
    public class TestController : ApiControllerBase
    {
        ITestBL _testBL;

        public TestController()
        {
        }

        [HttpPost]
        public BaseResponse<string> Test(string request)
        {
            _testBL = new TestBL();

            return _testBL.AddTest(request);
        }
    }
}
