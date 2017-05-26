using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZCMobileDemo.Lite.Controls
{
    /// <summary>
    /// Accordion class
    /// </summary>
    public class Accordion : ContentView
    {
        #region Private Variables
        List<AccordionSource> accordianDataSource;
        bool firstExpaned = false;
        StackLayout MainLayout;


        #endregion

        #region Constructors
        public Accordion()
        {
            var mainLayout = new StackLayout();
            Content = mainLayout;
        }
        public Accordion(List<AccordionSource> aSource)
        {
            accordianDataSource = aSource;
            DataBind();
        }
        #endregion

        #region Properties
        public List<AccordionSource> DataSource
        {
            get { return accordianDataSource; }
            set { accordianDataSource = value; }
        }
        public bool FirstExpaned
        {
            get { return firstExpaned; }
            set { firstExpaned = value; }
        }
        #endregion

        #region Public Methods
        public void DataBind()
        {
            var mainLayout = new StackLayout();

            var first = true;
            if (accordianDataSource != null)
            {
                foreach (var singleItem in accordianDataSource)
                {

                    var headerButton = new AccordionButton()
                    {
                        Text = singleItem.HeaderText,
                        TextColor = singleItem.HeaderTextColor,
                        BackgroundColor = singleItem.HeaderBackGroundColor
                    };

                    var accordionContent = new ContentView()
                    {
                        Content = singleItem.ContentItems,
                        IsVisible = false
                    };
                    if (first)
                    {
                        headerButton.Expand = firstExpaned;
                        accordionContent.IsVisible = firstExpaned;
                        first = false;
                    }
                    headerButton.AssosiatedContent = accordionContent;
                    headerButton.Clicked += OnAccordionButtonClicked;
                    mainLayout.Children.Add(headerButton);
                    mainLayout.Children.Add(accordionContent);
                }
            }
            MainLayout = mainLayout;
            Content = MainLayout;
        }

        void OnAccordionButtonClicked(object sender, EventArgs args)
        {
            var senderButton = (AccordionButton)sender;

            if (senderButton.Expand)
            {
                senderButton.Expand = false;
            }
            else
            {
                senderButton.Expand = true;
            }

            senderButton.AssosiatedContent.IsVisible = senderButton.Expand;
        }
        #endregion
    }
}
