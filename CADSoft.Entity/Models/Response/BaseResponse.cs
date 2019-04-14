using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADSoft.Entity.Models.Response
{
    public class BaseResponse<T>
    {
        public BaseResponse(T Response, bool IsValid, string Message)
        {
            this.Response = Response;
            this.IsValid = IsValid;
            this.Message = Message;
        }

        public BaseResponse(T Response)
        {
            this.Response = Response;
            this.IsValid = true;
            this.Message = "Success";
        }

        public T Response { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
