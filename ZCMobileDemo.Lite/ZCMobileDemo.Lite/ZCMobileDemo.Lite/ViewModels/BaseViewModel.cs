using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        #region Events
        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
