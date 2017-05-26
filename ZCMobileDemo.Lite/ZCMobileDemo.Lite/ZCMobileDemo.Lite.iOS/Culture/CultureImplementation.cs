using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Interfaces;
using System.Threading;

[assembly: Dependency(typeof(ZCMobileDemo.Lite.iOS.Culture.CultureImplementation))]
namespace ZCMobileDemo.Lite.iOS.Culture
{
    public class CultureImplementation : ILocalization
    {
        public CultureInfo GetCurrentCulture()
        {
            //var netLanguage = "en";
            //var androidLocale = Java.Util.Locale.Default;
            //var netLanguage = Thread.CurrentThread.CurrentCulture; //androidLocale.ToString().Replace("_", "-");
            // this gets called a lot - try/catch can be expensive so consider caching or something
            System.Globalization.CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            }
            catch (CultureNotFoundException e1)
            {

            }
            return ci;
        }

        public void SetCulture(CultureInfo cl)
        {
            Thread.CurrentThread.CurrentCulture = cl;
        }
    }
}