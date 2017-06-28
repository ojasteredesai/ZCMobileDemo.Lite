using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTimesheets : ContentPage
    {
        public ViewTimesheets()
        {
            InitializeComponent();
            BindingContext = new ViewTimsheetViewModel();
            App.ApplicationDataViewModel = BindingContext;
        }

        
    }
}