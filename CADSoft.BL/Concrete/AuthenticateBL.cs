using CADSoft.BL.Abstract;
using CADSoft.Core.Tokenizer;
using CADSoft.DAL.Abstract;
using CADSoft.DAL.Concrete;
using CADSoft.Entity.DBContext;
using CADSoft.Entity.Models;
using CADSoft.Entity.Models.Request;
using CADSoft.Entity.Models.Response;
using System;
using System.Web.Script.Serialization;

namespace CADSoft.BL.Concrete
{
    public class AuthenticateBL : IAuthenticateBL
    {
        RMContext context;
        ISessionPreviewDAL _sessionPreviewDAL;
        IUserDAL _userDAL;
        ISessionDAL _sessionDAL;
        ICompanyDAL _companyDAL;
        SessionBL sessionBL = new SessionBL();

        public AuthenticateBL()
        {
            context = new RMContext();
            _sessionPreviewDAL = new SessionPreviewDAL(context);
            _userDAL = new UserDAL(context);
            _sessionDAL = new SessionDAL(context);
            _companyDAL = new CompanyDAL(context);
        }

        public BaseResponse<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            AuthenticationResponse response = new AuthenticationResponse();

            if (request.Password == null || request.UserName == null)
            {
                throw new Exception("Username or Password Can Not Be Null");
            }

            User user = _userDAL.Get(x => x.UserName == request.UserName);
            if (user == null)
            {
                throw new Exception("Wrong Username or Password.");
            }

            Company company = _companyDAL.Get(x => x.ID == user.CompanyID);
            if (company == null)
            {
                throw new Exception("Wrong Username or Password.");
            }

            if (user.PasswordHash == request.Password)
            {
                response.Token = JWTBusiness.GenerateToken(request.UserName);
                SessionPreview model = new SessionPreview() {
                    ExpiryDate = DateTime.Now.AddHours(1),
                    Token = response.Token,
                    UserID = user.ID,
                    CreateUserID = user.ID,
                    UpdateUserID = user.ID
                };
                _sessionPreviewDAL.Add(model);

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
                sessionBL.SetCurrentPrincipal(userInfo);

                return new BaseResponse<AuthenticationResponse>(response);
            }
            else
            {
                return new BaseResponse<AuthenticationResponse>(null, false, "Login Failed");
            }
        }

        public void ValidetaAuthenticationHeader(string header)
        {
            if (string.IsNullOrEmpty(header))
            {
                throw new ArgumentNullException("auhentication-header");
            }

            AuthenticationHeader authHeader;

            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                authHeader = jss.Deserialize<AuthenticationHeader>(header);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (authHeader == null)
                throw new Exception("Authentication Header Not Found");
            if (authHeader.UserID <= 0)
                throw new Exception("Missing UserId Credential From Request");
            if (string.IsNullOrEmpty(authHeader.Token))
                throw new Exception("Missing UserId Credential From Request");
            if (string.IsNullOrEmpty(authHeader.TimeSpan))
                throw new Exception("Missing TimeSpan Credential From Request");

            ValidateToken(authHeader.Token);
        }

        public void ValidateToken(string token)
        {
            SessionPreview sPreview = _sessionPreviewDAL.Get(x => x.Token == token);
            if (sPreview == null)
            {
                throw new Exception("Not Authorized For This Request.");
            }
            if (sPreview.ExpiryDate <= DateTime.Now)
            {
                _sessionDAL.Add(new Session()
                {
                    CreateUserID = sPreview.CreateUserID,
                    ExpiryDate = sPreview.ExpiryDate,
                    Token = sPreview.Token,
                    UpdateUserID = sPreview.UpdateUserID,
                    UserID = sPreview.UserID
                });
                _sessionPreviewDAL.HardDelete(sPreview);
                throw new Exception("Session Expired!");
            }
            sPreview.ExpiryDate = DateTime.Now.AddHours(1);
            _sessionPreviewDAL.Update(sPreview);

            string username = sPreview.User.UserName;

            var tokenUsername = JWTBusiness.ValidateToken(token);

            if (username != tokenUsername)
            {
                throw new Exception("Not Authorized For This Request.");
            }

            sessionBL.GetSessionModel(tokenUsername);
        }
    }
}
