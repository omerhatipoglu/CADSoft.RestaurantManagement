using CADSoft.DAL.Abstract;
using CADSoft.Entity.DBContext;

namespace CADSoft.DAL.Concrete
{
    public class SessionPreviesDAL : BaseRepository<SessionPreview>, ISessionPreviewDAL
    {
        public SessionPreviesDAL(RMContext context) : base(context)
        {
        }
    }
}
