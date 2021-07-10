using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uh.ViewModels.BaseRequestResponse
{
    public interface IResponseBase
    {
        string RequestId { get; set; }
        int StatusCode { get; set; }
        string Message { get; set; }

        List<ErrorInfo> ErrorInfo { get; set; }
    }
}
