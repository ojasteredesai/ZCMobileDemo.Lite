using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Controls;
using ZCMobileDemo.Lite.Model;
using ZCMobileDemo.Lite.Utility;
using ZCMobileDemo.Lite.Views.Timesheet;

namespace ZCMobileDemo.Lite.ViewModels
{
    public class ApproveTimesheetViewModel : BaseViewModel
    {
        #region Private Members
        //   private MasterDetailViewModel masterDetailViewModel;
        //  IServiceCaller service;
        #endregion

        #region Properties
        public int Skip { get; set; }
        //public int Take { get; set; }

        private string _imageName = "checkBGOff.png";

        public string ImageName
        {
            get { return _imageName; }
            set
            {
                _imageName = value;
                RaisePropertyChanged("ImageName");
            }
        }
       // public bool IsCheckAll { get; set; }
        private bool _isCheckAll;

        public bool IsCheckAll
        {
            get { return _isCheckAll; }
            set { _isCheckAll = value;
                RaisePropertyChanged("IsCheckAll");
            }
        }

        public bool IsSelected { get; set; }
        private ObservableCollection<ApproveTimesheet> _allApproveTimesheets;
        public ObservableCollection<ApproveTimesheet> AllApproveTimesheets
        {
            get { return _allApproveTimesheets ?? (_allApproveTimesheets = new ObservableCollection<ApproveTimesheet>()); }
            set
            {
                _allApproveTimesheets = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ApproveTimesheet> _allFilterApproveTimesheets;
        public ObservableCollection<ApproveTimesheet> AllFilterApproveTimesheets
        {
            get
            {
                if (_allFilterApproveTimesheets == null)
                {
                    _allFilterApproveTimesheets = new ObservableCollection<ApproveTimesheet>
                    {
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 1",
                            BusinessUnit = "Business Unit 2",
                            PayAmount = "$ 50.00",
                            ImageSource = "checkBGOff.png",
                            TimesheetID = 1

                        },
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 2",
                            BusinessUnit = "Business Unit 2",
                            PayAmount = "$ 51.00",
                            ImageSource = "checkBGOff.png",
                             TimesheetID = 2
                        },
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 3",
                            BusinessUnit = "Business Unit 3",
                            PayAmount = "$ 52.00",
                            ImageSource = "checkBGOff.png",
                             TimesheetID = 3
                        },
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 4",
                            BusinessUnit = "Business Unit 4",
                            PayAmount = "$ 53.00",
                            ImageSource = "checkBGOff.png",
                             TimesheetID = 4
                        },
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 5",
                            BusinessUnit = "Business Unit 5",
                            PayAmount = "$ 54.00",
                            ImageSource = "checkBGOff.png",
                             TimesheetID = 5
                        },
                         new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 6",
                            BusinessUnit = "Business Unit 6",
                            PayAmount = "$ 50.00",
                            ImageSource = "checkBGOff.png",
                            TimesheetID = 6

                        },
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 7",
                            BusinessUnit = "Business Unit 7",
                            PayAmount = "$ 51.00",
                            ImageSource = "checkBGOff.png",
                             TimesheetID = 7
                        },
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 8",
                            BusinessUnit = "Business Unit 8",
                            PayAmount = "$ 52.00",
                            ImageSource = "checkBGOff.png",
                             TimesheetID = 8
                        },
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 9",
                            BusinessUnit = "Business Unit 9",
                            PayAmount = "$ 53.00",
                            ImageSource = "checkBGOff.png",
                             TimesheetID = 9
                        },
                        new ApproveTimesheet {
                            ResourceName="Shweta Kulshrestha",
                            PeriodEnding= DateTime.Now.Date.ToString(),
                            ProjectName="Project 10",
                            BusinessUnit = "Business Unit 10",
                            PayAmount = "$ 54.00",
                            ImageSource = "checkBGOff.png",
                             TimesheetID = 10
                        }
                    };
                }
                return _allFilterApproveTimesheets;
            }
            set { _allFilterApproveTimesheets = value; RaisePropertyChanged(); }
        }

        private List<string> _selectedtimesheets;

        public List<string> SelectedTimesheets
        {
            get { return _selectedtimesheets ?? (_selectedtimesheets = new List<string>()); }
            set { _selectedtimesheets = value; RaisePropertyChanged(); }
        }
        private ApproveTimesheet _SeletedApproveTimesheet;

        public ApproveTimesheet SeletedApproveTimesheet
        {
            get { return _SeletedApproveTimesheet ?? (_SeletedApproveTimesheet = new ApproveTimesheet()); }
            set { _SeletedApproveTimesheet = value; RaisePropertyChanged(); }
        }

        bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    RaisePropertyChanged("IsLoading");
                }
            }
        }
        private ApproveTimesheet _selectedApproveTimesheet;
        public ApproveTimesheet SelectedApproveTimesheet
        {
            get { return _selectedApproveTimesheet; }
            set
            {
                _selectedApproveTimesheet = value;
                GoToDetailPage();
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public ApproveTimesheetViewModel()
        {
            LoadApproveTimesheetCommand = new RelayCommand(FilterApproveTimesheet);

            FilterApproveTimesheet();
        }
        #endregion

        #region Commands
        private RelayCommand _ApproveTimesheet;

        public RelayCommand ApproveTimesheetCommand
        {
            get
            {
                return _ApproveTimesheet ?? (_ApproveTimesheet = new RelayCommand(() =>
            {
                if (SelectedTimesheets != null && SelectedTimesheets.Count > 0)
                {
                    //approve code
                }
            }));
            }
            set { _ApproveTimesheet = value; }
        }

        private RelayCommand _DeclineTimesheetCommand;

        public RelayCommand DeclineTimesheetCommand
        {
            get
            {
                return _DeclineTimesheetCommand ?? (_DeclineTimesheetCommand = new RelayCommand(() =>
                {

                    if (SelectedTimesheets != null && SelectedTimesheets.Count > 0)
                    {
                        //Decline Code for timesheet
                    }

                }));
            }
            set { _DeclineTimesheetCommand = value; }
        }

        private RelayCommand _CheckAllCommand;

        public RelayCommand CheckAllCommand
        {
            get
            {
                return _CheckAllCommand ?? (_CheckAllCommand = new RelayCommand(() =>
          {
              IsCheckAll = !IsCheckAll;
              IsSelected = IsCheckAll;
              // ImageSourceCheckAll = IsCheckAll ? "checkMatrixBG.png" : "checkBGOff.png";
              AllApproveTimesheets.Select(c => { c.ImageSource = (IsCheckAll ? "checkMatrixBG.png" : "checkBGOff.png"); ; return c; }).ToObservableCollection();
              RaisePropertyChanged("AllApproveTimesheets");
              if (IsCheckAll)
              {
                  SelectedTimesheets = AllApproveTimesheets.Select(c => c.TimesheetID.ToString()).ToList();
              }
              else
              {
                  SelectedTimesheets.Clear();
              }
          }));
            }
            set { _CheckAllCommand = value; }
        }

        private RelayCommand<ApproveTimesheet> _SelectedApproveTimesheetCommand;

        public RelayCommand<ApproveTimesheet> SelectedApproveTimesheetCommand
        {
            get
            {
                return _SelectedApproveTimesheetCommand ?? (_SelectedApproveTimesheetCommand = new RelayCommand<ApproveTimesheet>((item) =>
                {
                    if (item.ImageSource.ToLower() == "checkmatrixbg.png")
                        IsSelected = true;
                    else
                        IsSelected = false;
                    IsSelected = !IsSelected;
                    AllApproveTimesheets.Where(x => x.TimesheetID == item.TimesheetID).
                                                                    Select(c => { c.ImageSource = (IsSelected ? "checkMatrixBG.png" : "checkBGOff.png"); return c; }).ToObservableCollection();
                    if (IsSelected)
                    {
                        SelectedTimesheets.Add(item.TimesheetID.ToString());
                    }
                    else
                    {
                        SelectedTimesheets.Remove(item.TimesheetID.ToString());
                        IsCheckAll = false;
                        MessagingCenter.Send<object, bool>(this, "CheckAll", IsCheckAll);
                    }
                    if (SelectedTimesheets.Count == AllApproveTimesheets.Count)
                    {
                        IsCheckAll = true;
                        MessagingCenter.Send<object, bool>(this, "CheckAll", IsCheckAll);
                    }
                    else
                    {
                        IsCheckAll = false;
                        MessagingCenter.Send<object, bool>(this, "CheckAll", IsCheckAll);

                    }
                }));
            }
            set { _SelectedApproveTimesheetCommand = value; }
        }

        public RelayCommand LoadApproveTimesheetCommand { get; set; }

        #endregion

        #region Public Methods


        #endregion

        #region Private methods
        private void FilterApproveTimesheet()
        {
            this.IsLoading = true;
            if (AllApproveTimesheets.Count <= 5)
            {
                ObservableCollection<ApproveTimesheet> _filterdata;
                _filterdata = AllFilterApproveTimesheets.Skip(AllApproveTimesheets.Count).Take(App.Take).ToObservableCollection();
                // _filterdata[_filterdata.Count - 1].IsLastTimesheet = true;
                foreach (ApproveTimesheet item in _filterdata)
                {
                    AllApproveTimesheets.Add(item);
                }
                RaisePropertyChanged("AllApproveTimesheets");
                this.IsLoading = false;

            }
            // AllApproveTimesheets = AllApproveTimesheets.Select();
            //this.IsLoading = true;
            //service = new ServiceCaller();
            ////viewTimesheetRequest = new ViewTimesheetRequest();
            //ViewTimesheetListRequest.ContactID = (App.UserSession.CurrentUserInfo.UserTypeID == 2 ? App.UserSession.LoggedonUser.userID : 0);
            //ViewTimesheetListRequest.ResourceID = (App.UserSession.CurrentUserInfo.UserTypeID == 1 ? App.UserSession.LoggedonUser.userID : 0);
            //ViewTimesheetListRequest.loggedonUser = App.UserSession.LoggedonUser;
            //ViewTimesheetListRequest.Offset = start;
            //ViewTimesheetListRequest.PageSize = numberOfRecords;

            //await service.CallHostService<ViewTimesheetRequest, ViewTimesheetObjectResponse>(ViewTimesheetListRequest, "FilterTimesheetsForSearchRequest", (r) =>
            //{
            //    if (r.resultSuccess)
            //    {
            //        Timesheets = r.timesheets.ToObservableCollection();
            //        Timesheets[numberOfRecords - 1].IsLastItem = true;
            //        RaisePropertyChanged("Timesheets");
            //        this.IsLoading = false;
            //    }
            //    else
            //    {
            //        MasterDetailViewModel.Detail.DisplayAlert("Error", r.resultMessages.FirstOrDefault().ToString(), "ok");
            //    }

            //});
        }
        private void GoToDetailPage()
        {

            if (SelectedApproveTimesheet == null)
                return;

            App.MasterDetailVM.IsExecuting = true;
            var bindingContext = this;
            App.ApplicationDataViewModel = new Page2ViewModel { Messsge1 = "", Messsge2 = "" };

            var navigationData = new ZCMobileNavigationData
            {
                CurrentPage = new ApproveTimesheets(),
                CurrentPageTitle = App.MasterDetailVM.Header,
                NextPage = new Page2(),
                NextPageTitle = App.PageTitels["page2"]
            };

            App.MasterDetailVM.PushAsync(navigationData);
            App.MasterDetailVM.IsExecuting = false;
        }

        #endregion
    }
    public class ApproveTimesheet : BaseViewModel
    {
        public int ProjectID { get; set; }
        public int TimesheetID { get; set; }
        public string ResourceCodeResourceID { get; set; }
        public string ResourceName { get; set; }
        public string ProjectName { get; set; }
        public string PeriodEnding { get; set; }
        public string PayAmount { get; set; }
        public string TimesheetPayAmount { get; set; }
        public string ZcBillAmount { get; set; }
        public int? Adjusted { get; set; }
        public bool IsApprovalReady { get; set; }
        public string SubmitDate { get; set; }
        public string Units { get; set; }
        public int ProjStatusID { get; set; }
        public string ProjStatus { get; set; }
        public int ResourceID { get; set; }
        public string Status { get; set; }
        public int TimeStatusID { get; set; }
        public string BillCurrencyCode { get; set; }
        public string PayCurrencyCode { get; set; }
        public string TotalAmount { get; set; }
        public bool IsLastTimesheet { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int? VendorID { get; set; }
        public string TotalHours { get; set; }
        public string BusinessUnit { get; set; }

        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                RaisePropertyChanged();

            }
        }


    }
}
