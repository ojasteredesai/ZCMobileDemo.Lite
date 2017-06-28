using System;
using Xamarin.Forms;

namespace ZCMobileDemo.Lite.Controls
{
    public class CustomeButton : Button
    {
        public CustomeButton()
        {
            this.FontSize = 16;
            this.TextColor = Color.White;
        }
        public Typeenum BackColor { get; set; }
    }
    public enum Typeenum
    {
        Orange = 0,
        Blue = 1,
        NoColor = 2,
    }
}
