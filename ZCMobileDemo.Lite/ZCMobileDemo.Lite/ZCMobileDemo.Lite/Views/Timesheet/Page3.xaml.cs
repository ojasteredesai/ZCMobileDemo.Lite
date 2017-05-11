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
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            //App.MasterDetailVM.Header = App.MasterDetailVM.Header1;
            ////App.MasterDetailVM.Header1 = "Page 4";
            //App.MasterDetailVM.Header1 = App.PageTitels["page4"];
            //App.MasterDetailVM.PushAsync(this);
            //App.MasterDetailVM.PushAsync1(new Page4());

            var navigationData = new ZCMobileNavigationData
            {
                CurrentPage = this,
                CurrentPageTitle = App.MasterDetailVM.Header1,
                NextPage = new Page4(),
                NextPageTitle = App.PageTitels["page4"]
            };

            App.MasterDetailVM.PushAsync(navigationData);
        }
    }
}
