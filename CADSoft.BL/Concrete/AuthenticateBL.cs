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
        ISessionPreviewDAL _sessionPreviewDAL = new SessionPreviesDAL(new RMContext());

        public BaseResponse<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            AuthenticationResponse response = new AuthenticationResponse();

            if (request.Password == null || request.UserName == null)
            {
                throw new Exception("Username or Password Can Not Be Null");
            }

            if (request.UserName == "admin" && request.Password == "123")
            {
                new SessionBL().SetCurrentPrincipal(new UserInfo() {
                    UserName = request.UserName,
                    Password = request.Password,
                    BirthDate = DateTime.Now,
                    Email = "aaa@ccc.com",
                    ID = 1,
                    Name = "Emirhan",
                    Surname = "Aksoy",
                    PhoneNumber = "0000000000"
                });

                response.Token = JWTBusiness.GenerateToken(request.UserName);
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
                throw new Exception("Missing UserId Credetial From Request");
            if (string.IsNullOrEmpty(authHeader.Token))
                throw new Exception("Missing UserId Credetial From Request");
            if (string.IsNullOrEmpty(authHeader.TimeSpan))
                throw new Exception("Missing TimeSpan Credetial From Request");

            ValidateToken(authHeader.Token);
        }

        public void ValidateToken(string token)
        {
            //DataBase Token kontrol tablosuna istek atıp username i alıcaz
            string username = "admin";

            var tokenUsername = JWTBusiness.ValidateToken(token);

            if (username != tokenUsername)
            {
                throw new Exception("Not Authorized For This Request.");
            }
        }
    }
}
