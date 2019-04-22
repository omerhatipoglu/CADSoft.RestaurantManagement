using CADSoft.BL.Abstract;
using CADSoft.DAL.Abstract;
using CADSoft.DAL.Concrete;
using CADSoft.Entity.ComContext;
using CADSoft.Entity.Models.Response;

namespace CADSoft.BL.Concrete
{
    public class TestBL : ITestBL
    {
        ComContext context;
        ITestDAL _testDAL;

        public TestBL()
        {
            context = new ComContext(SessionBL.CurrentUser.ConnectionString);
            _testDAL = new TestDAL(context);
        }

        public BaseResponse<string> AddTest(string test)
        {
            Test model = new Test() { Name = test };
            _testDAL.Add(model);
            return new BaseResponse<string>(test);
        }
    }
}
