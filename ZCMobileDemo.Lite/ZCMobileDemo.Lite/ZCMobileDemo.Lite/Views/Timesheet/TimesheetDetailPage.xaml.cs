using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesheetDetailPage : ContentPage
    {
      //  public MasterDetailViewModel MasterDetailVM { get; set; }
        public TimesheetDetailPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // MasterDetailVM.Detail = this;
            //MasterDetailVM.Detail1 = new NeedMoreInfoPage();
            //MasterDetailVM.Detail = MasterDetailVM.NavigationStack.Last(); 
            App.MasterDetailVM.PushAsync1(new NeedMoreInfoPage());
            App.MasterDetailVM.PopAsync();
        }
    }
}
