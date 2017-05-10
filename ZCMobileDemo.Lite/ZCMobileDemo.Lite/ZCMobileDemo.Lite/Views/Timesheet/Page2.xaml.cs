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
    public partial class Page2 : ContentPage
    {
      //  public MasterDetailViewModel MasterDetailVM { get; set; }
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // MasterDetailVM.Detail = this;
            //MasterDetailVM.Detail1 = new NeedMoreInfoPage();
            //MasterDetailVM.Detail = MasterDetailVM.NavigationStack.Last(); 
            App.MasterDetailVM.PushAsync(this);
            App.MasterDetailVM.PushAsync1(new Page3());
        }
    }
}
