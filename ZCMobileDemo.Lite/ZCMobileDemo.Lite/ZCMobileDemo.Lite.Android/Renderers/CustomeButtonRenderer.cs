using System;
using Android.Views;
//using Android.Widget;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Droid.Renderers;
using ZCMobileDemo.Lite.Controls;

[assembly: ExportRenderer(typeof(CustomeButton), typeof(CustomeButtonRenderer))]
namespace ZCMobileDemo.Lite.Droid.Renderers
{
    public class CustomeButtonRenderer:ButtonRenderer
    {
        public CustomeButtonRenderer()
        {
        }
		/// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);

			var elementButton = this.Element as CustomeButton;			
			Android.Widget.Button thisButton = Control as Android.Widget.Button;
           
			thisButton.SetAllCaps(false);           
			thisButton.Touch += (object sender, Android.Views.View.TouchEventArgs e2) =>
						{
							if (e2.Event.Action == MotionEventActions.Down)
							{
								System.Diagnostics.Debug.WriteLine("TouchDownEvent");							
							}
							else if (e2.Event.Action == MotionEventActions.Up)
							{
								System.Diagnostics.Debug.WriteLine("TouchUpEvent");
								Control.CallOnClick();
							}
						};                     
			if (elementButton.BackColor == Typeenum.Orange)
				Control.SetBackgroundDrawable(CreateGradientColor("#ffb85c", "#d25903", "#FFF6923F"));
			else if (elementButton.BackColor == Typeenum.Blue)
				Control.SetBackgroundDrawable(CreateGradientColor("#3c9ece", "#01446b", "#FFB95454"));
            else if (elementButton.BackColor == Typeenum.NoColor)
                elementButton.BackgroundColor = Color.Transparent;
            else Control.SetBackgroundDrawable(CreateGradientColor("#3c9ece", "#01446b", "#FF98B954"));
		} 
        /// <summary>
        /// Creates the color of the gradient.
        /// </summary>
        /// <returns>The gradient color.</returns>
        /// <param name="color1">Color1.</param>
        /// <param name="color2">Color2.</param>
        /// <param name="borderColor">Border color.</param>
		private GradientDrawable CreateGradientColor(string color1, string color2, string borderColor)
		{
			GradientDrawable gd = new GradientDrawable(
			GradientDrawable.Orientation.TopBottom,
			new int[] { Color.FromHex(color1).ToAndroid().ToArgb(), Color.FromHex(color2).ToAndroid().ToArgb() });
			//gd.SetCornerRadius(0f);
			//gd.SetStroke(5, Color.FromHex(borderColor).ToAndroid());
			return gd;
		}

	}
}
