using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ZCMobileDemo.Lite.Interfaces;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(ZCMobileDemo.Lite.Droid.Culture.CultureImplementation))]
namespace ZCMobileDemo.Lite.Droid.Culture
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