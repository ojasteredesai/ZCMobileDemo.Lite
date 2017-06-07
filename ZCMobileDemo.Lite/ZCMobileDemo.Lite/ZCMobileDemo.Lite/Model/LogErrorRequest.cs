using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCMobileDemo.Lite.Model
{
    public class LogErrorRequest 
    {
        //public object UIException { get; set; }
        public string ErrorMessage { get; set; }
        public string Title { get; set; }        
    }

    public class LogErrorResponse
    {
        public bool ResultSuccess { get; set; }
    }
}
