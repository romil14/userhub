using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uh.ViewModels.BaseRequestResponse
{
    public class Response<T> 
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public T ResponseInfo { get; set; }

        public List<ErrorInfo> ErrorInfo { get; set; }
    }
}
