using CADSoft.DAL.Abstract;
using CADSoft.Entity.DBContext;

namespace CADSoft.DAL.Concrete
{
    public class UserDAL : BaseRepository<User>, IUserDAL
    {
        public UserDAL(RMContext context) : base(context)
        {

        }
    }
}
