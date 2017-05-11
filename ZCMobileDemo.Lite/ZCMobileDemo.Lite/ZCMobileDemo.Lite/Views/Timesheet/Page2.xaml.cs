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
            App.MasterDetailVM.Header = App.MasterDetailVM.Header1;
            //App.MasterDetailVM.Header1 = "Page 3";
            App.MasterDetailVM.Header1 = App.PageTitels["page3"];
            App.MasterDetailVM.PushAsync(this);
            App.MasterDetailVM.PushAsync1(new Page3());
        }
    }
}
