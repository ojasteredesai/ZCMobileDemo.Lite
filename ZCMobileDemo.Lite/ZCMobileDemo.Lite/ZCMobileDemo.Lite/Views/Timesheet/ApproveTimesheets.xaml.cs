using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.Controls;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApproveTimesheets : ContentPage
    {
        #region Property
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        #endregion

        public ApproveTimesheets()
        {
            InitializeComponent();
            this.BindingContext = new ApproveTimesheetViewModel();
            App.ApplicationDataViewModel = BindingContext;
        }
        #region Private Method


        private void lst_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if ((e != null) && (e.Item != null))
            {
                ListView lv = sender as ListView;

                if (lv != null)
                    lv.SelectedItem = null;
            }
        }
       
       
        #endregion
    }
}