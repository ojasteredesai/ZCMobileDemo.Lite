using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZCMobileDemo.Lite.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBoxControl : ContentView
    {
        public static readonly BindableProperty TextProperty =
           BindableProperty.Create(
               "Text",
               typeof(string),
               typeof(CheckBoxControl),
               null,
               propertyChanged: (bindable, oldValue, newValue) =>
               {
                   ((CheckBoxControl)bindable).textLabel.Text = (string)newValue;
               });
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(
                "FontSize",
                typeof(double),
                typeof(CheckBoxControl),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    CheckBoxControl checkbox = (CheckBoxControl)bindable;
                    checkbox.boxLabel.FontSize = (double)newValue;
                    checkbox.textLabel.FontSize = (double)newValue;
                });
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create("IsChecked", typeof(bool), typeof(CheckBoxControl), false, propertyChanged: (bindable, oldValue, newValue) =>
            {
                // Set the graphic. 
                CheckBoxControl checkbox = (CheckBoxControl)bindable;
                if (checkbox.Isspecial)
                {
                    checkbox.boxLabel.Text = (bool)newValue ? "\u2612" : "\u2610";
                }
                else
                {
                    checkbox.boxLabel.Text = (bool)newValue ? "\u2611" : "\u2610";
                }
                // Fire the event. 
                EventHandler<bool> eventHandler = checkbox.CheckedChanged;
                if (eventHandler != null)
                { eventHandler(checkbox, (bool)newValue); }
            });
        public event EventHandler<bool> CheckedChanged;
        public CheckBoxControl()
        {
            InitializeComponent();

        }
        public bool Isspecial { get; set; }
        public string Text
        {
            set
            {
                SetValue(TextProperty, value);
            }
            get
            {
                return (string)GetValue(TextProperty);
            }
        }
        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            set
            {
                SetValue(FontSizeProperty, value);
            }
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
        }
        public bool IsChecked
        {
            set
            {
                SetValue(IsCheckedProperty, value);
            }
            get
            {
                return (bool)GetValue(IsCheckedProperty);
            }
        }
        // TapGestureRecognizer handler. 
        void OnCheckBoxTapped(object sender, EventArgs args)
        {
            IsChecked = !IsChecked;
        }
       
    }
}