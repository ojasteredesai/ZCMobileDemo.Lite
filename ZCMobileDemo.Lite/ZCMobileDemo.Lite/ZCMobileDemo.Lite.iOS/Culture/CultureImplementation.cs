using Foundation;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Interfaces;

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
        public string GetCurrent()
        {
            #region output all the values for testing - not needed in production code
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;
            Console.WriteLine("nslocaleid:" + iosLocaleAuto);
            Console.WriteLine("nslanguage:" + iosLanguageAuto);

            var iosLocale = NSLocale.CurrentLocale.LocaleIdentifier;
            var iosLanguage = NSLocale.CurrentLocale.LanguageCode;

            var netLocale = iosLocale.Replace("_", "-");
            var netLanguage = iosLanguage.Replace("_", "-");

            Console.WriteLine("ios:" + iosLanguage + " " + iosLocale);
            Console.WriteLine("net:" + netLanguage + " " + netLocale);

            // doesn't seem to affect anything (well, i didn't expect it to affect UIKit controls)
            //			var ci = new System.Globalization.CultureInfo ("JA-jp");
            //			System.Threading.Thread.CurrentThread.CurrentCulture = ci;

            #endregion

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                Console.WriteLine("NSLocale.PreferredLanguages [0]:" + NSLocale.PreferredLanguages[0]);

                netLanguage = pref.Replace("_", "-"); // for .NET-ification

                // -- Handling unsupported langauge codes --
                // Schwiizertüütsch (Swiss German)
                if (NSLocale.AutoUpdatingCurrentLocale.LanguageCode == "gsw")
                {
                    netLanguage = "de-CH"; // TODO: attempt to detect/use locale set by user too
                }

            }

            Console.WriteLine("preferred now:" + netLanguage);
            return netLanguage;
        }

        public void SetLocale()
        {

            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var netLocale = iosLocaleAuto.Replace("_", "-");
            System.Globalization.CultureInfo ci;
            try
            {
                ci = new System.Globalization.CultureInfo(netLocale);
            }
            catch
            {
                ci = new System.Globalization.CultureInfo(GetCurrent());
            }
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        public void SetCulture(string netLocale)
        {
            System.Globalization.CultureInfo ci;
            try
            {
                ci = new System.Globalization.CultureInfo(netLocale);
            }
            catch
            {
                ci = new System.Globalization.CultureInfo(GetCurrent());
            }
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}