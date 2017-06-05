using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Extension;
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
