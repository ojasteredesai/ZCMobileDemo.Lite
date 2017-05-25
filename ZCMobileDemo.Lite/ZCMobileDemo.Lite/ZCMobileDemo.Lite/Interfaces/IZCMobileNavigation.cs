using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZCMobileDemo.Lite.Interfaces
{
    /// <summary>
    /// IZCMobileNavigation is derived from INavigation. It defines additional navigation features required by ZCMobile
    /// </summary>
    public interface IZCMobileNavigation : INavigation
    {
        void RemoveAllPages();
        void RemoveAllInitialPages();
        Task PushAsync1(Page page);
        Task PushAsync1(Page page, bool animated);
        Task<Page> PushAsyncPreviousPage(Page previousPage = null);
        Task<Page> PopAsync1();
        Task<Page> PopAsync1(bool animated);
        void AdjustScreenOnOrientationChange(bool orientationChanges = false);
        Task<Page> PopAsyncInitialPages(bool logoutRequest = false);
    }
}
