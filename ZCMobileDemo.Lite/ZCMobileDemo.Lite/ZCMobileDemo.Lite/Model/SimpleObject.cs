using System.Collections.Generic;

namespace ZCMobileDemo.Lite.Model
{

    public class SimpleObject
    {
        public SimpleObject()
        {
            ChildItemList = new List<ChildItems>();
        }
        public string HeaderText { get; set; }
        public List<ChildItems> ChildItemList { get; set; }
    }
}
