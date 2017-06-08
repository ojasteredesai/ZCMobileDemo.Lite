using Xamarin.Forms;

namespace ZCMobileDemo.Lite.Behaviors
{
    /// <summary>
    /// Require Field Validator Will validate the Entry if entry is enpty 
    /// </summary>
    public class RequiredValidatorBehavior : Behavior<Entry>
    {
        #region Bindable Properties
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(RequiredValidatorBehavior), true);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;
        #endregion

        #region Properties
        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }
        #endregion

        #region Consructor
        public RequiredValidatorBehavior()
        {
        }
        #endregion


        #region Events
        protected override void OnAttachedTo(Entry entry)
        {
            base.OnAttachedTo(entry);
            entry.TextChanged += HandleTextChanged;
            entry.Focused += Entry_Focused;
        }

        void Entry_Focused(object sender, FocusEventArgs e)
        {
            if (!e.IsFocused)
            {
                IsValid = !string.IsNullOrWhiteSpace(((Entry)sender).Text);
            }

        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = !string.IsNullOrWhiteSpace(e.NewTextValue);
            //((Entry)sender).BackgroundColor = IsValid ? Color.Default : Color.Red;
        }


        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            bindable.Focused -= Entry_Focused;
            base.OnDetachingFrom(bindable);

        }
        #endregion


    }
}
