using Xamarin.Forms;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite
{
    public partial class MainPage : ContentPage
    {
        #region Constructors
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
        public MainPage(bool show)
        {
            InitializeComponent();
            backButton.IsVisible = show;
            
        }
        #endregion

    }
}
