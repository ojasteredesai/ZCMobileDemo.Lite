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
        private Page _detail, _detail1;
        private INavigation _navigation;

        private Stack<Page> _pages = new Stack<Page>();
        #endregion

        #region Properties

        public Page Detail
        {
            get { return _detail; }
            set
            {
                if (_detail != value)
                {
                    //if (Detail != null && Detail.StyleId != value.StyleId)
                    //{
                    //    _pages.Push(Detail);
                    //}
                    if (Detail != null && (_pages.Any() && _pages.Any(x => x.StyleId == value.StyleId)))
                    {
                        _pages.Pop();
                    }
                    if (Detail != null)
                    {
                        _pages.Push(Detail);
                    }
                    _detail = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Page Detail1
        {
            get { return _detail1; }
            set
            {
                if (_detail1 != value)
                {
                    //  if (Detail1 != null && Detail1.StyleId != value.StyleId)
                    if (Detail1 != null && (_pages.Any() && _pages.Any(x => x.StyleId == value.StyleId)))
                    {
                        _pages.Pop();
                    }
                    if (Detail1 != null)
                    {
                        _pages.Push(Detail1);
                    }
                    _detail1 = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string header;

        public string Header
        {
            get { return header; }
            set { header = value; RaisePropertyChanged(); }
        }
        private string rightButton;

        public string RightButton
        {
            get { return rightButton; }
            set { rightButton = value; RaisePropertyChanged(); }
        }

        private string header1;

        public string Header1
        {
            get { return header1; }
            set { header1 = value; RaisePropertyChanged(); }
        }
        private string _RightButton1;

        public string RightButton1
        {
            get { return _RightButton1; }
            set { _RightButton1 = value; RaisePropertyChanged(); }
        }

        public Task<Page> PopAsync()
        {
            Page page = null;
            if (_pages.Count > 0)
            {
                page = _pages.Pop();
                _detail = page;
                RaisePropertyChanged("Detail");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync();
        }
        public IReadOnlyList<Page> ModalStack { get { return _navigation.ModalStack; } }

        public IReadOnlyList<Page> NavigationStack
        {
            get
            {
                if (_pages.Count == 0)
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
                beforeMaster.AddRange(_pages);
                beforeMaster.AddRange(implPages.Where(d => !beforeMaster.Contains(d)
                    && d != master));
                return new ReadOnlyCollection<Page>(_navigation.NavigationStack.ToList());
            }
        }
        #endregion

        #region Public Methods
        public void InsertPageBefore(Page page, Page before)
        {
            if (_pages.Contains(before))
            {
                var list = _pages.ToList();
                var indexOfBefore = list.IndexOf(before);
                list.Insert(indexOfBefore, page);
                _pages = new Stack<Page>(list);
            }
            else
            {
                _navigation.InsertPageBefore(page, before);
            }
        }


        public Task<Page> PopAsync(bool animated)
        {
            Page page = null;
            if (_pages.Count > 0)
            {
                page = _pages.Pop();
                _detail = page;
                RaisePropertyChanged("Detail");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync(animated);
        }

        public Task<Page> PopAsync1(bool animated)
        {
            Page page = null;
            if (_pages.Count > 0)
            {
                page = _pages.Pop();
                _detail1 = page;
                RaisePropertyChanged("Detail1");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync(animated);
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
                _pages = new Stack<Page>(new[] { _pages.FirstOrDefault() });
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
                _pages = new Stack<Page>(new[] { _pages.FirstOrDefault() });
                return Task.FromResult(firstPage);
            }
            return _navigation.PopToRootAsync(animated);
        }

        public Task PushAsync1(Page page)
        {
            Detail1 = page;
            return Task.FromResult(page);
        }

        public Task PushAsync(Page page)
        {
            Detail = page;
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
            if (_pages.Contains(page))
            {
                var list = _pages.ToList();
                list.Remove(page);
                _pages = new Stack<Page>(list);
            }
            _navigation.RemovePage(page);
        }

        public void SetNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }

        //protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion
    }
}
