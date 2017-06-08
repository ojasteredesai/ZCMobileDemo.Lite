
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        #region Constructors
        public Page1()
        {
            InitializeComponent();
            var model = App.ApplicationDataViewModel as Page1ViewModel;
            this.BindingContext = (model != null ? model : (new Page1ViewModel()));
        }
        #endregion
    }
}
