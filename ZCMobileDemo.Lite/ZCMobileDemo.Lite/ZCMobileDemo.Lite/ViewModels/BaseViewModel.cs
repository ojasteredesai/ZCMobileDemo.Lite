using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZCMobileDemo.Lite.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties
        private MasterDetailViewModel _MasterDetailViewModel;

        public MasterDetailViewModel MasterDetailViewModel
        {
            get { return _MasterDetailViewModel; }
            set { _MasterDetailViewModel = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
