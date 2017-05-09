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
    public partial class ViewTimesheetPage : ContentPage
    {
     //   public MasterDetailViewModel MasterDetailVM { get; set; }

        public ViewTimesheetPage()
        {
            InitializeComponent();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            var page = new TimesheetDetailPage();
            //  page.MasterDetailVM = this.MasterDetailVM;            
            App.MasterDetailVM.Detail1 = page;
        }
    }
}
