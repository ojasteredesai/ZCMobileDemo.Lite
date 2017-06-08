using Xamarin.Forms;

namespace ZCMobileDemo.Lite.Controls
{
    /// <summary>
    /// AccordionButton class
    /// </summary>
    public class AccordionButton : Button
    {
        #region Private Variables
        bool expand = false;
        #endregion

        #region Constructors
        public AccordionButton()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            BorderColor = Color.Black;
            BorderRadius = 0;
            BorderWidth = 0;
        }
        #endregion 

        #region Properties
        public bool Expand
        {
            get { return expand; }
            set { expand = value; }
        }
        public ContentView AssosiatedContent
        { get; set; }
        #endregion
    }
}
