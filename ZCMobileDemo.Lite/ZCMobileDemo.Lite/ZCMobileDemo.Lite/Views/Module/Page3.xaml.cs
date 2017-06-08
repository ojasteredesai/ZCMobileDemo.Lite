
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        #region Constructors
        public Page3()
        {
            InitializeComponent();
            var model = App.ApplicationDataViewModel as Page3ViewModel;
            this.BindingContext = (model != null ? model : (new Page3ViewModel()));
        }
        #endregion

       
    }
}
