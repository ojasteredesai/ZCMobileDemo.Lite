namespace ZCMobileDemo.Lite.Model
{
    public class DropDownItem
    {
        public DropDownItem()
        {
        }
        public DropDownItem(string name, string value, int? ShareWithID = null)
        {
            this.Name = name;
            this.Value = value;
            this.ShareWithID = ShareWithID;
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public int? ShareWithID { get; set; }
    }
}
