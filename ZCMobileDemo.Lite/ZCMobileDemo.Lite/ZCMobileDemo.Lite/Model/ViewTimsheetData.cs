using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZCMobileDemo.Lite.Model;

namespace ZCMobileDemo.Lite
{
    public class ViewTimsheetData
    {
        static ObservableCollection<ViewTimesheet> _allViewTimesheets;
        public static ObservableCollection<ViewTimesheet> AllViewTimesheets
        {
            get
            {
                if (_allViewTimesheets == null)
                {
                    _allViewTimesheets = new ObservableCollection<ViewTimesheet>
                    {
                        new ViewTimesheet {
                            periodEnding= DateTime.Now.Date.ToString(),
                            projectName="TimeSheet Project 1",
                            projStatus = "Active",
                            payAmount = "$ 50.00"
                        },
                        new ViewTimesheet {
                             periodEnding= DateTime.Now.Date.ToString(),
                            projectName="TimeSheet Project 2",
                            projStatus = "Active",
                            payAmount = "$ 51.00"
                        },
                        new ViewTimesheet {
                            periodEnding= DateTime.Now.Date.ToString(),
                            projectName="TimeSheet Project 3",
                            projStatus = "Active",
                            payAmount = "$ 52.00"
                        },
                        new ViewTimesheet {
                            periodEnding= DateTime.Now.Date.ToString(),
                            projectName="TimeSheet Project 4",
                            projStatus = "Active",
                            payAmount = "$ 53.00"
                        },
                        new ViewTimesheet {
                            periodEnding= DateTime.Now.Date.ToString(),
                            projectName="TimeSheet Project 5",
                            projStatus = "Active",
                            payAmount = "$ 54.00"
                        }
                    };
                }
                return _allViewTimesheets;
            }
        }

       
    }
}