using CADSoft.DAL.Abstract;
using CADSoft.Entity.DBContext;

namespace CADSoft.DAL.Concrete
{
    public class SessionPreviewDAL : BaseRepository<SessionPreview, RMContext>, ISessionPreviewDAL
    {
        public SessionPreviewDAL(RMContext context) : base(context)
        {
        }
    }
}
