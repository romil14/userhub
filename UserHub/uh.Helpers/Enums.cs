using System.ComponentModel;

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
