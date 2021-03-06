﻿
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        #region Constructors
        public Page2()
        {
            InitializeComponent();
            var model = App.ApplicationDataViewModel as Page2ViewModel;
            this.BindingContext = (model != null ? model : (new Page2ViewModel()));
        }
        #endregion

 
    }
}
