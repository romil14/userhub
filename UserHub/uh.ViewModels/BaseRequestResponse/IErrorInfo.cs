using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uh.ViewModels.BaseRequestResponse
{
    public interface IErrorInfo
    {
        string Message { get; set; }
        string ErrorCode { get; set; }
    }
}
