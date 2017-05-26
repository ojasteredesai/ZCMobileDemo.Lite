using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;
using ZCMobileDemo.Lite.Views.Module;

namespace ZCMobileDemo.Lite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        #region Constructors
        public LoginPage()
        {
            InitializeComponent();
            if (App.MasterDetailVM != null)
            {
                App.MasterDetailVM.Header = "Login Page";
            }
            this.BindingContext = new LoginViewModel();
        }
        #endregion
    }
}
