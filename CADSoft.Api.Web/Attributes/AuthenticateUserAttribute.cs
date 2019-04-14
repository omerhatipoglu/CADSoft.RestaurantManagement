using CADSoft.BL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace CADSoft.Api.Web.Attributes
{
    public class AuthenticateUserAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple { get { return false; } }

        private string ExtractAuthHeader(HttpAuthenticationContext context)
        {
            try
            {
                return context.Request.Headers.GetValues("authentication-header").FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string authHeader = ExtractAuthHeader(context);
            AuthenticateBL authBL = new AuthenticateBL();
            authBL.ValidetaAuthenticationHeader(authHeader);

            return Task.FromResult("ok");
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}