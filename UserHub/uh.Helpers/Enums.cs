using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uh.Helpers
{
    public enum ResponseStatus 
    {
        [Description("Success")]
        Success = 1,
        [Description("Failed")]
        Failed = 2,
        [Description("No Data")]
        NoData = 3
    }

    

  
}
