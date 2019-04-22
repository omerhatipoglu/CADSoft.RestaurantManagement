using CADSoft.DAL.Abstract;
using CADSoft.Entity.DBContext;

namespace CADSoft.DAL.Concrete
{
    public class SessionDAL : BaseRepository<Session, RMContext>, ISessionDAL
    {
        public SessionDAL(RMContext context) : base(context)
        {

        }
    }
}
