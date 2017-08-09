using System;
using Xamarin.Forms;


namespace ZCMobileDemo.Lite.Controls
{
    public class ZCTimePicker : Entry
	{
		public CustTimePicker dt
		{
			get;
			set;
		}
		public string Timeformate { get; set; }
		public ZCTimePicker()
		{
         
			dt = new CustTimePicker();
            this.Focused += _customeEntry_Focused;

		}
		private void _customeEntry_Focused(object sender, FocusEventArgs e)
		{
			var parent = this.Parent as StackLayout;
			//dt.ClassId = "dtTimePicker";
			//if (Parent as Grid != null)
			//{
			//	(Parent as Grid).Children.Add(dt);
			//}
			//else if (Parent as StackLayout != null)
			//{
			//	(Parent as StackLayout).Children.Add(dt);
			//}
			dt.Unfocused += dt_unfocused;
			parent.Children.Add(dt);
			Device.BeginInvokeOnMainThread(() =>
			{
				dt.Focus();
			});
			if (Device.RuntimePlatform == Device.iOS)
			{

				if (!string.IsNullOrEmpty(Timeformate))
				{
					DateTime dateTime = DateTime.MinValue.Add(dt.Time);
					this.Text = dateTime.ToString(Timeformate);

				}
				else
				{
					this.Text = dt.Time.ToString();
				}

				////MessagingCenter.Subscribe<MessageClass>(this, "Not update", (obj) =>
				////  {
				//if (obj.Title == "done")
					  //{
						 // if (!string.IsNullOrEmpty(Timeformate))
						 // {
							//  DateTime dateTime = DateTime.MinValue.Add(dt.Time);
							//  this.Text = dateTime.ToString(Timeformate);

						 // }
						 // else
						 // {
       //                     this.Text = dt.Time.ToString();
						 // }

					  //}
					 // MessagingCenter.Unsubscribe<MessageClass>(this, "Not update");
				 // });

			}
		}

		private void dt_unfocused(object s, FocusEventArgs e)
		{
			try
			{
				var selectedTime = s as TimePicker;
				var parent = this.Parent as StackLayout;

				if (Device.RuntimePlatform == Device.Android)
				{
                    this.Text = selectedTime.Time.ToString();
				}
				parent.Children.Remove(selectedTime);
			}
			catch (Exception ex)
			{
				//EventLogger.HandleException(ex);
				// System.Diagnostics.Debug.WriteLine(ex);
			}

		}


	}

	public class CustTimePicker : TimePicker
	{
		public CustTimePicker()
		{

		}
	}

}