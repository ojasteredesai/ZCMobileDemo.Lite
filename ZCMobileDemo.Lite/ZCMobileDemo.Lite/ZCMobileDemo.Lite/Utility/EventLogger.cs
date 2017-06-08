using System;
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
