using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.Utility;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        #region Constructors
        public LoginPage()
        {
            try
            {
                InitializeComponent();
                if (App.MasterDetailVM != null)
                {
                    App.MasterDetailVM.Header = "Login Page";
                }
                this.BindingContext = new LoginViewModel();
                //int i = 2, j = 0;
                //var k = i / j;
            }
            catch (Exception ex)
            {
                EventLogger.LogException(ex);
            }
            #endregion

        }
    }
}
