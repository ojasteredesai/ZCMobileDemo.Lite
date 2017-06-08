using System;
using System.Collections.Generic;

namespace ZCMobileDemo.Lite.Model
{
    public class UserDefinedFields
    {
        public string ID { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public Nullable<int> MaximumLength { get; set; }
        public int ControlID { get; set; }
        public List<DropDownItem> UserDefinedDropDown { get; set; }
        public bool? Visible { get; set; } // added for ZMOB-3106
        public bool IsUDFBool { get; set; }
        //Non-table properties.
        public bool IsDisabled { get; set; }
    }
}
