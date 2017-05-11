using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Views;

namespace ZCMobileDemo.Lite.ViewModels
{
    /// <summary>
    /// MasterDetailControlViewModel class.
    /// </summary>
    public class MasterDetailControlViewModel : BaseViewModel, INavigation
    {
        #region Private Members
        private string header;
        private string header1;
        private string rightButton;
        private string rightButton1;
        private Page detail, detail1;
        private INavigation _navigation;
        private Stack<Page> pages = new Stack<Page>();
        private bool secondContentVisibility = false;
        private int detailGridColSpan = 2;
        private int detailGridHeaderColSpan = 4;
        #endregion

        #region Public Properties
        #region Detail Container properties
        public Page Detail
        {
            get { return detail; }
            set
            {
                if (detail != value)
                {
                    //if (Detail != null && Detail.StyleId != value.StyleId)
                    //{
                    //    _pages.Push(Detail);
                    //}
                    if (Detail != null && (pages.Any() && pages.Any(x => x.StyleId == value.StyleId)))
                    {
                        pages.Pop();
                    }
                    if (value != null)
                    {
                        pages.Push(value);
                    }
                    detail = value;
                    RaisePropertyChanged();
                }

                //This will maintain visibility of second detail page.
                App.MasterDetailVM.SecondContentVisibility = (pages.Count > 1);
                App.MasterDetailVM.DetailGridColSpan = pages.Count > 1 ? 1 : 2;
                App.MasterDetailVM.DetailGridHeaderColSpan = pages.Count > 1 ? 1 : 4;
            }
        }

        public Page Detail1
        {
            get { return detail1; }
            set
            {
                if (detail1 != value)
                {
                    //  if (Detail1 != null && Detail1.StyleId != value.StyleId)
                    if (Detail1 != null && (pages.Any() && pages.Any(x => x.StyleId == value.StyleId)))
                    {
                        pages.Pop();
                    }
                    if (value != null)
                    {
                        pages.Push(value);
                        App.MasterDetailVM.SecondContentVisibility = true;
                        App.MasterDetailVM.DetailGridColSpan = 1;
                        App.MasterDetailVM.DetailGridHeaderColSpan = 1;
                    }
                    detail1 = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region Right Button and Header Properties
        public string Header
        {
            get { return header; }
            set { header = value; RaisePropertyChanged(); }
        }

        public string Header1
        {
            get { return header1; }
            set { header1 = value; RaisePropertyChanged(); }
        }

        public string RightButton
        {
            get { return rightButton; }
            set { rightButton = value; RaisePropertyChanged(); }
        }

        public string RightButton1
        {
            get { return rightButton1; }
            set { rightButton1 = value; RaisePropertyChanged(); }
        }
        #endregion

        #region Navigation Properties
        public IReadOnlyList<Page> ModalStack { get { return _navigation.ModalStack; } }

        public IReadOnlyList<Page> NavigationStack
        {
            get
            {
                if (pages.Count == 0)
                {
                    return _navigation.NavigationStack;
                }
                var implPages = _navigation.NavigationStack;
                MasterDetailControl master = null;
                var beforeMaster = implPages.TakeWhile(d =>
                {
                    master = d as MasterDetailControl;
                    return master != null || d.GetType() == typeof(MasterDetailControl);
                }).ToList();
                beforeMaster.AddRange(pages);
                beforeMaster.AddRange(implPages.Where(d => !beforeMaster.Contains(d)
                    && d != master));
                return new ReadOnlyCollection<Page>(_navigation.NavigationStack.ToList());
            }
        }
        #endregion

        #region Visibility Control and Grid ColumnSpan Properties
        public bool SecondContentVisibility
        {
            get
            {
                return secondContentVisibility;
            }
            set
            {
                secondContentVisibility = value;
                RaisePropertyChanged();
            }
        }
        public int DetailGridColSpan
        {
            get
            {
                return detailGridColSpan;
            }
            set
            {
                detailGridColSpan = value;
                RaisePropertyChanged();
            }
        }
        public int DetailGridHeaderColSpan
        {
            get
            {
                return detailGridHeaderColSpan;
            }
            set
            {
                detailGridHeaderColSpan = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #endregion

        #region Push and Pop Methods
        public Task PushAsync(Page page)
        {
            Detail = page;
            return Task.FromResult(page);
        }
        public Task PushAsync1(Page page)
        {
            Detail1 = page;
            return Task.FromResult(page);
        }

        public Task PushAsync(Page page, bool animated)
        {
            Detail = page;
            return Task.FromResult(page);
        }

        public Task PushAsync1(Page page, bool animated)
        {
            Detail1 = page;
            return Task.FromResult(page);
        }

        public Task<Page> PopAsync1()
        {
            Page page = null;
            Page page1 = null;
            if (pages.Count > 0)
            {
                if (pages != null && pages.Count > 2)
                {
                    pages.Pop();
                    page = pages.Pop();
                    page1 = pages.Pop();
                    PushAsync(page1);
                    PushAsync1(page);
                }
                else//if (pages != null && pages.Count == 1)
                {
                    page = pages.Pop();
                    PushAsync(Detail);
                    // PushAsync1(Detail);
                }
                //_detail = page;
                RaisePropertyChanged("Detail");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync();
        }

        public Task<Page> PopAsync()
        {
            Page page = null;
            if (pages.Count > 0)
            {
                page = pages.Pop();
                detail = page;
                RaisePropertyChanged("Detail");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync();
        }

        public Task<Page> PopAsync(bool animated)
        {
            Page page = null;
            if (pages.Count > 0)
            {
                page = pages.Pop();
                detail = page;
                RaisePropertyChanged("Detail");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync(animated);
        }

        public Task<Page> PopAsync1(bool animated)
        {
            Page page = null;
            if (pages.Count > 0)
            {
                page = pages.Pop();
                detail1 = page;
                RaisePropertyChanged("Detail1");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync(animated);
        }

        public void InsertPageBefore(Page page, Page before)
        {
            if (pages.Contains(before))
            {
                var list = pages.ToList();
                var indexOfBefore = list.IndexOf(before);
                list.Insert(indexOfBefore, page);
                pages = new Stack<Page>(list);
            }
            else
            {
                _navigation.InsertPageBefore(page, before);
            }
        }

        public Task<Page> PopModalAsync()
        {
            return _navigation.PopModalAsync();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return _navigation.PopModalAsync(animated);
        }

        public Task PopToRootAsync()
        {
            var firstPage = _navigation.NavigationStack[0];
            if (firstPage is MasterDetailControl
                || firstPage.GetType() == typeof(MasterDetailControl))
            {
                pages = new Stack<Page>(new[] { pages.FirstOrDefault() });
                return Task.FromResult(firstPage);
            }
            return _navigation.PopToRootAsync();
        }

        public Task PopToRootAsync(bool animated)
        {
            var firstPage = _navigation.NavigationStack[0];
            if (firstPage is MasterDetailControl
                || firstPage.GetType() == typeof(MasterDetailControl))
            {
                pages = new Stack<Page>(new[] { pages.FirstOrDefault() });
                return Task.FromResult(firstPage);
            }
            return _navigation.PopToRootAsync(animated);
        }

        public Task PushModalAsync(Page page)
        {
            return _navigation.PushModalAsync(page);
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return _navigation.PushModalAsync(page, animated);
        }

        public void RemovePage(Page page)
        {
            if (pages.Contains(page))
            {
                var list = pages.ToList();
                list.Remove(page);
                pages = new Stack<Page>(list);
            }
            _navigation.RemovePage(page);
        }

        public void RemoveAllPages()
        {
            if (pages.Count > 0)
            {
                pages.Clear();
            }
        }

        public void SetNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }
        #endregion
    }
}
