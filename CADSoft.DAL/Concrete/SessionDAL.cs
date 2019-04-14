using CADSoft.DAL.Abstract;
using CADSoft.Entity.DBContext;

namespace CADSoft.DAL.Concrete
{
    public class SessionDAL : BaseRepository<Session>, ISessionDAL
    {
        public SessionDAL(RMContext context) : base(context)
        {

        }
    }
}
