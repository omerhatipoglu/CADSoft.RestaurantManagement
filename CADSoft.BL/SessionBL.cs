using CADSoft.DAL.Abstract;
using CADSoft.DAL.Concrete;
using CADSoft.Entity.DBContext;
using CADSoft.Entity.Models;
using System;
using System.Threading;
using System.Web;

namespace CADSoft.BL
{
    public class SessionBL
    {
        readonly static string SessionName = "RMSession";
        RMContext context;
        IUserDAL _userDAL;
        ICompanyDAL _companyDAL;

        public SessionBL()
        {
            context = new RMContext();
            _userDAL = new UserDAL(context);
            _companyDAL = new CompanyDAL(context);
        }

        public static UserInfo CurrentUser { get; set; }

        public void SetCurrentPrincipal(UserInfo user)
        {
            Identity identity = new Identity(user);
            Principal principal = new Principal(identity);

            HttpContext.Current.User = principal;
        }

        public UserInfo GetSessionModel(string username)
        {
            var user = _userDAL.Get(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("Wrong Username or Password.");
            }

            Company company = _companyDAL.Get(x => x.ID == user.CompanyID);
            if (company == null)
            {
                throw new Exception("Wrong Username or Password.");
            }

            UserInfo userInfo = new UserInfo()
            {
                UserName = user.UserName,
                Password = user.PasswordHash,
                Email = user.Email,
                ID = user.ID,
                Name = user.Name,
                Surname = user.Surname,
                ConnectionString = "data source=" + company.DBIP + ";initial catalog=" + company.DBName + ";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
            };

            CurrentUser = userInfo;

            return userInfo;
        }
    }
}
