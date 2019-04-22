using CADSoft.Entity.Models.Response;

namespace CADSoft.BL.Abstract
{
    public interface ITestBL
    {
        BaseResponse<string> AddTest(string test);
    }
}
