using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.Model;

namespace ZCMobileDemo.Lite.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page5 : ContentPage
    {
        public Page5()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            //App.MasterDetailVM.Header = App.MasterDetailVM.Header1;
            ////App.MasterDetailVM.Header1 = "Page 6";
            //App.MasterDetailVM.Header1 = App.PageTitels["page6"];
            //App.MasterDetailVM.PushAsync(this);
            //App.MasterDetailVM.PushAsync1(new Page6());
            var navigationData = new ZCMobileNavigationData
            {
                CurrentPage = this,
                CurrentPageTitle = App.MasterDetailVM.Header1,
                NextPage = new Page6(),
                NextPageTitle = App.PageTitels["page6"]
            };

            App.MasterDetailVM.PushAsync(navigationData);
        }
    }
}
