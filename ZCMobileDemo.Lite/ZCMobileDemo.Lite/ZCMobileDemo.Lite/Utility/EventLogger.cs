using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCMobileDemo.Lite.Interfaces;
using ZCMobileDemo.Lite.Model;
using ZCMobileDemo.Lite.Services;

namespace ZCMobileDemo.Lite.Utility
{
    public static class EventLogger
    {
        public static void LogException(Exception ex)
        {
            IServiceCaller serviceCaller = new ServiceCaller();
            var request = new LogErrorRequest { ErrorMessage = ex.ToString(), Title = "ZCMobile UI Exception - " + ex.Source };
            serviceCaller.CallHostService<LogErrorRequest, LogErrorResponse>(request, "loginrequest", (r) =>
            {

            });
        }
    }
}
