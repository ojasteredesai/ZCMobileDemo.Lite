using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZCMobileDemo.Lite.ViewModels;
using ZCMobileDemo.Lite.Views;

namespace ZCMobileDemo.Lite
{
    public partial class MainPage : ContentPage
    {
        #region Constructors
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
        public MainPage(bool show)
        {
            InitializeComponent();
            backButton.IsVisible = show;
            
        }
        #endregion

    }
}
