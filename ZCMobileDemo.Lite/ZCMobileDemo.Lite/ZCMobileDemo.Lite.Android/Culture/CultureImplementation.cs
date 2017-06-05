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
        public void SetLocale()
        {

            var androidLocale = Java.Util.Locale.Default; // user's preferred locale
            var netLocale = androidLocale.ToString().Replace("_", "-");
            var ci = new System.Globalization.CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
           
        }
        public string GetCurrent()
        {
            var androidLocale = Java.Util.Locale.Default;

            //var netLanguage = androidLocale.Language.Replace ("_", "-");
            var netLanguage = androidLocale.ToString().Replace("_", "-");

            //var netLanguage = androidLanguage.Replace ("_", "-");
            Console.WriteLine("ios:" + androidLocale.ToString());
            Console.WriteLine("net:" + netLanguage);

            Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            Console.WriteLine(Thread.CurrentThread.CurrentUICulture);

            return netLanguage;
        }
        public void SetCulture(string netLocale)
        {
            var ci = new System.Globalization.CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
           
        }
    }
}