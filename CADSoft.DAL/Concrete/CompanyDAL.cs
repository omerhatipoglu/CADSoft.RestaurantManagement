using CADSoft.DAL.Abstract;
using CADSoft.Entity.DBContext;

namespace CADSoft.DAL.Concrete
{
    public class CompanyDAL : BaseRepository<Company, RMContext>, ICompanyDAL
    {
        public CompanyDAL(RMContext context) : base(context)
        {

        }
    }
}
