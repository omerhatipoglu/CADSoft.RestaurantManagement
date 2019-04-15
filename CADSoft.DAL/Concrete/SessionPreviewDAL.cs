using CADSoft.DAL.Abstract;
using CADSoft.Entity.DBContext;

namespace CADSoft.DAL.Concrete
{
    public class SessionPreviewDAL : BaseRepository<SessionPreview>, ISessionPreviewDAL
    {
        public SessionPreviewDAL(RMContext context) : base(context)
        {
        }
    }
}
