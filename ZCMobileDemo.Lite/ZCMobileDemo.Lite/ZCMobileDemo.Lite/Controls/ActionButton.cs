using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ZCMobileDemo.Lite.Controls
{
    public class ActionButtons : StackLayout
    {
        #region Private Property and Variable
             
        public bool IsCheckAll { get; set; }
        CustomeButton btnPrimary = new CustomeButton();
        CustomeButton btnSecondary = new CustomeButton();
        CustomeButton btnTertiary = new CustomeButton();
        Label lblAll = new Label();
        CustomeButton btnCheckAll = new CustomeButton();

        #endregion

        #region Constructor
        public ActionButtons()
        {
            LoadControl();
        }

        #endregion

        #region Primary Button 


        public static readonly BindableProperty PrimaryTextProperty = BindableProperty.Create("PrimaryText", typeof(string), typeof(ActionButtons), default(string),
               propertyChanged: (bindable, oldValue, newValue) =>
               {
                   var actbtn = bindable as ActionButtons;
                   oldValue = newValue;
                   actbtn.btnPrimary.Text = (string)newValue;
               });

        public string PrimaryText
        {
            get { return (string)GetValue(PrimaryTextProperty); }
            set { SetValue(PrimaryTextProperty, value); }
        }

        public static readonly BindableProperty PrimaryCommandProperty =
            BindableProperty.Create("PrimaryCommand", typeof(ICommand), typeof(ActionButtons), default(ICommand));

        public ICommand PrimaryCommand
        {
            get { return (ICommand)GetValue(PrimaryCommandProperty); }
            set { SetValue(PrimaryCommandProperty, value); }
        }

        #endregion

        #region Secondary Button
        public static readonly BindableProperty SecondaryTextProperty = BindableProperty.Create("SecondaryText", typeof(string), typeof(ActionButtons), default(string),
             propertyChanged: (bindable, oldValue, newValue) =>
             {
                 var actbtn = bindable as ActionButtons;
                 oldValue = newValue;
                 actbtn.btnSecondary.Text = (string)newValue;
             });

        public string SecondaryText
        {
            get { return (string)GetValue(SecondaryTextProperty); }
            set { SetValue(SecondaryTextProperty, value); }
        }

        public static readonly BindableProperty SecondaryCommandProperty =
            BindableProperty.Create("SecondaryCommand", typeof(ICommand), typeof(ActionButtons), default(ICommand));

        public ICommand SecondaryCommand
        {
            get { return (ICommand)GetValue(SecondaryCommandProperty); }
            set { SetValue(SecondaryCommandProperty, value); }
        }
        #endregion

        #region Tertiary Button
        //Text Property
        public static readonly BindableProperty TertiaryTextProperty = BindableProperty.Create("TertiaryText", typeof(string), typeof(ActionButtons), default(string),
             propertyChanged: (bindable, oldValue, newValue) =>
             {
                 var actbtn = bindable as ActionButtons;
                 oldValue = newValue;
                 actbtn.btnTertiary.Text = (string)newValue;
             });

        public string TertiaryText
        {
            get { return (string)GetValue(TertiaryTextProperty); }
            set { SetValue(TertiaryTextProperty, value); }
        }
        //Command Property
        public static readonly BindableProperty TertiaryCommandProperty =
            BindableProperty.Create("SecondaryCommand", typeof(ICommand), typeof(ActionButtons), default(ICommand));

        public ICommand TertiaryCommand
        {
            get { return (ICommand)GetValue(TertiaryCommandProperty); }
            set { SetValue(TertiaryCommandProperty, value); }
        }
        //visibility property
        public static readonly BindableProperty IsVisibleTertiaryProperty = BindableProperty.Create("IsVisibleTertiary", typeof(bool), typeof(ActionButtons), true, BindingMode.TwoWay,
             propertyChanged: (bindable, oldValue, newValue) =>
             {
                 var actbtn = bindable as ActionButtons;
                 oldValue = newValue;
                 actbtn.btnTertiary.IsVisible = (bool)newValue;
             });

        public bool IsVisibleTertiary
        {
            get { return (bool)GetValue(IsVisibleTertiaryProperty); }
            set { SetValue(IsVisibleTertiaryProperty, value); }
        }
        #endregion

        #region CheckAll Button
        //Commands
        public static readonly BindableProperty CheckAllCommandProperty =
          BindableProperty.Create("CheckAllCommand", typeof(ICommand), typeof(ActionButtons), default(ICommand));

        public ICommand CheckAllCommand
        {
            get { return (ICommand)GetValue(CheckAllCommandProperty); }
            set
            {
                SetValue(CheckAllCommandProperty, value);
                IsCheckAll = !IsCheckAll;
                btnCheckAll.Image = IsCheckAll ? "checkMatrixBG.png" : "checkBGOff.png";
            }
        }
        //visibility
        public static readonly BindableProperty IsVisibleCheckAllProperty = BindableProperty.Create("IsVisibleCheckAll", typeof(bool), typeof(ActionButtons), true, BindingMode.TwoWay,
             propertyChanged: (bindable, oldValue, newValue) =>
             {
                 var actbtn = bindable as ActionButtons;
                 oldValue = newValue;
                 actbtn.btnCheckAll.IsVisible = (bool)newValue;
                 actbtn.lblAll.IsVisible = (bool)newValue;
             });

        public bool IsVisibleCheckAll
        {
            get { return (bool)GetValue(IsVisibleCheckAllProperty); }
            set { SetValue(IsVisibleCheckAllProperty, value); }
        }
        #endregion

        #region Private methods
        private void BtnPrimary_Clicked(object sender, EventArgs e)
        {
            if (PrimaryCommand != null && PrimaryCommand.CanExecute(null))
                PrimaryCommand.Execute(null);
        }
        private void BtnSecondary_Clicked(object sender, EventArgs e)
        {
            if (SecondaryCommand != null && SecondaryCommand.CanExecute(null))
                SecondaryCommand.Execute(null);
        }
        private void BtnTertiary_Clicked(object sender, EventArgs e)
        {
            if (TertiaryCommand != null && TertiaryCommand.CanExecute(null))
                TertiaryCommand.Execute(null);
        }
        private void BtnCheckAll_Clicked(object sender, EventArgs e)
        {
            var rbtn = sender as CustomeButton;
            IsCheckAll = !IsCheckAll;
            rbtn.Image = IsCheckAll ? "checkMatrixBG.png" : "checkBGOff.png";
            if (CheckAllCommand != null && CheckAllCommand.CanExecute(null))
                CheckAllCommand.Execute(null);
        }
        private void CheckUncheckAll(object sender, bool ischeck)
        {
            IsCheckAll = ischeck;
            btnCheckAll.Image = IsCheckAll ? "checkMatrixBG.png" : "checkBGOff.png";
            MessagingCenter.Subscribe<object, bool>(this, "CheckAll", CheckUncheckAll);
        }

        private void LoadControl()
        {

            btnPrimary.Style = Application.Current.Resources["buttonStyle"] as Style;
            btnPrimary.BackColor = Typeenum.Orange;
            btnPrimary.Clicked += BtnPrimary_Clicked;

            btnSecondary.Style = Application.Current.Resources["buttonStyle"] as Style;
            btnSecondary.BackColor = Typeenum.Blue;
            btnSecondary.Clicked += BtnSecondary_Clicked;

            btnTertiary.Style = Application.Current.Resources["buttonStyle"] as Style;
            btnTertiary.BackColor = Typeenum.Blue;
            btnTertiary.Clicked += BtnTertiary_Clicked;
            btnTertiary.IsVisible = IsVisibleTertiary;

            lblAll.Text = "All";
            lblAll.FontAttributes = FontAttributes.Bold;
            lblAll.VerticalOptions = LayoutOptions.Center;

            btnCheckAll.Style = Application.Current.Resources["checkAllbuttonStyle"] as Style;
            btnCheckAll.BackColor = Typeenum.NoColor;
            btnCheckAll.Clicked += BtnCheckAll_Clicked;
            btnCheckAll.IsVisible = IsVisibleCheckAll;
            btnCheckAll.Image = "checkBGOff.png";

            Orientation = StackOrientation.Horizontal;
            Children.Add(btnPrimary);
            Children.Add(btnSecondary);
            Children.Add(btnTertiary);
            Children.Add(lblAll);
            Children.Add(btnCheckAll);

            MessagingCenter.Subscribe<object, bool>(this, "CheckAll", CheckUncheckAll);
        }
        #endregion
    }
}
