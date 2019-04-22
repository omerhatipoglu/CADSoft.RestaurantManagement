using CADSoft.DAL.Abstract;
using CADSoft.Entity.ComContext;

namespace CADSoft.DAL.Concrete
{
    public class TestDAL : BaseRepository<Test, ComContext>, ITestDAL
    {
        public TestDAL(ComContext context) : base(context)
        {
        }
    }
}
