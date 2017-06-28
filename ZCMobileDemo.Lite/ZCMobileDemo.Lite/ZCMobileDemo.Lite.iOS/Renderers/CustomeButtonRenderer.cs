using System;
using System.ComponentModel;
using CoreAnimation;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ZCMobileDemo.Lite.iOS.Renderers;
using ZCMobileDemo.Lite.Controls;

[assembly: ExportRenderer(typeof(CustomeButton), typeof(CustomeButtonRenderer))]
namespace ZCMobileDemo.Lite.iOS.Renderers
{
    public class CustomeButtonRenderer:ButtonRenderer
    {
		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			var elementButton = this.Element as CustomeButton;
			UIButton thisButton = Control as UIButton;
			thisButton.TouchDown += delegate
						{
							System.Diagnostics.Debug.WriteLine("TouchDownEvent");
						};
			thisButton.TouchUpInside += delegate
			{
				System.Diagnostics.Debug.WriteLine("TouchUpEvent");
			};
            if (elementButton.BackColor == Typeenum.Orange)
                Control.Layer.InsertSublayer(CreateGradientColor("#ffb85c", "#d25903", "#FFF6923F", Control.Bounds), 0);
            else if (elementButton.BackColor == Typeenum.Blue)
                Control.Layer.InsertSublayer(CreateGradientColor("#3c9ece", "#01446b", "#FFB95454", Control.Bounds), 0);
            else if (elementButton.BackColor == Typeenum.NoColor)
                elementButton.BackgroundColor = Color.Transparent;
            else Control.Layer.InsertSublayer(CreateGradientColor("#3c9ece", "#01446b", "#FFB95454", Control.Bounds), 0);
		}

		private CAGradientLayer CreateGradientColor(string color1, string color2, string borderColor, CGRect bounds)
		{
			var gradient = new CAGradientLayer();
			gradient.Frame = bounds;
			gradient.Colors = new CoreGraphics.CGColor[] { Color.FromHex(color1).ToCGColor(), Color.FromHex(color2).ToCGColor() };
			return gradient;
		}
	}
}
