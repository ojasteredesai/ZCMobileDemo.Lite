using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Interfaces;

namespace ZCMobileDemo.Lite.Utility
{
    public  class CultureUtility
    {
        const string ResourceId = "ZCMobileDemo.Lite.Resources.UIPageResources";
        public  string GetResxNameByValue(string value)
        {
            ResourceManager resmgr = new ResourceManager(ResourceId
                               , typeof(CultureUtility).GetTypeInfo().Assembly);

            CultureInfo ci = DependencyService.Get<ILocalization>().GetCurrentCulture();

            return resmgr.GetString(value, ci);
        }
    }
}
