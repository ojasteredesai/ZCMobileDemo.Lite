using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.Controls;
using ZCMobileDemo.Lite.ViewModels;

namespace ZCMobileDemo.Lite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesheetApproveList : ViewCell
    {
        #region Property
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        #endregion
        public TimesheetApproveList()
        {
            InitializeComponent();
           
        }

        void Timesheetclicked(object sender, EventArgs e)
        {
            var vm = App.ApplicationDataViewModel as ApproveTimesheetViewModel;

            var senderButton = (RoundedButton)sender;

            IsSelected = !IsSelected;

            if (IsSelected)
            {
                senderButton.Image = "checkMatrixBG.png";
            }
            else
            {
                senderButton.Image = "checkBGOff.png";
            }
            
            if (IsSelected)
            {
                vm.SelectedTimesheets.Add(senderButton.CommandParameter.ToString());
            }
            else
            {
                vm.SelectedTimesheets.Remove(senderButton.CommandParameter.ToString());

            }
            //Call command from viewmodel     
            //if ((vm != null) && (vm.TimesheetSelected.CanExecute(null)))
            //    vm.TimesheetSelected.Execute(null);
        }
    }
}