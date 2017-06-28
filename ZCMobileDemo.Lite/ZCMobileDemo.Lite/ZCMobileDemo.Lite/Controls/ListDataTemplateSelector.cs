using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZCMobileDemo.Lite.Model;

namespace ZCMobileDemo.Lite
{
    public class ListDataTemplateSelector : DataTemplateSelector
    {
        DataTemplate listViewTemplate;
        DataTemplate listApproveTemplate;
        public string ViewModule { get; set; }
        public bool ApproveListType { get; set; }
        public ListDataTemplateSelector()
        {
          
           
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
             //var lstview = container as ListView;

            //if (lstview == null)
            //    return null;
            switch (ViewModule)
            {
                case "Timesheet":
                    listViewTemplate = new DataTemplate(typeof(TimesheetListView));
                    listApproveTemplate = new DataTemplate(typeof(TimesheetApproveList));
                    break;
            }

            return ApproveListType ? listApproveTemplate : listViewTemplate;
        }
    }
}