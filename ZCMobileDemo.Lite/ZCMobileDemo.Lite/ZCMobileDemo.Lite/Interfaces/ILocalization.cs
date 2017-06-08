using System.Globalization;

namespace ZCMobileDemo.Lite.Interfaces
{
    public interface ILocalization
    {
        CultureInfo GetCurrentCulture();
        void SetCulture(string cl);

       
    }
}
