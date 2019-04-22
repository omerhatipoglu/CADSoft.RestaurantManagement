using CADSoft.Api.Web.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CADSoft.Api.Web
{
    [AuthenticateUser]
    public class ApiControllerBase : ApiController
    {
    }
}