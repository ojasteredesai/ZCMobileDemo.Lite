using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views.Module
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dossier : ContentPage
    {
        public Dossier()
        {
            InitializeComponent();
            BindingContext = new DossierViewModel();
        }
    }
}