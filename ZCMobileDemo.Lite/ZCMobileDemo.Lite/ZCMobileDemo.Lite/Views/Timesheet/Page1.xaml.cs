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
    public partial class Page1 : ContentPage
    {
        //   public MasterDetailViewModel MasterDetailVM { get; set; }

        public Page1()
        {
            InitializeComponent();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            var page = new Page2();
            App.MasterDetailVM.Header1 =App.PageTitels["page2"];
            App.MasterDetailVM.PushAsync1(page);
        }
    }
}
