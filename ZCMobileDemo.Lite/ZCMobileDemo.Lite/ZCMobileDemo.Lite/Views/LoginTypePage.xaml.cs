
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginTypePage : ContentPage
    {
        #region Constructor
        public LoginTypePage()
        {
            InitializeComponent();
            App.MasterDetailVM.Header = "Login Type Page";
            this.BindingContext = new LoginViewModel();
        }
        #endregion
    }
}