using XamarinStarter.Abstractions;
using XamarinStarter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinStarter.ViewModels
{
    public class BaseViewModel : NotifyPropertyChange
    {

        #region Exposing behaviour from "ContentPage" class during wiring ViewModel

        //For exposing Navigation behaviour from "ContentPage" class
        public INavigation Navigation { get; set; }

        //For exposing DisplayAlert behaviour from "ContentPage" class
        public delegate Task ShowAlertMessageDelegate(string title, string message, string okaybutton);
        public ShowAlertMessageDelegate ShowAlertMessage;

        //For exposing DisplayAlert with response behaviour from "ContentPage" class
        public delegate Task<bool> ShowAlertMessageResponseDelegate(string title, string message, string okaybutton, string cancelButton);
        public ShowAlertMessageResponseDelegate ShowAlertMessageResponse;

        #endregion

        #region common properties for all viewModels

        private string _pageIsBusyMessage = "";
        public string PageIsBusyMessage
        {
            get { return _pageIsBusyMessage; }
            set
            {
                _pageIsBusyMessage = value;
                NotifyPropertyChanged(nameof(PageIsBusyMessage));
            }
        }

        private bool _pageIsBusy;
        public bool PageIsBusy
        {
            get { return _pageIsBusy; }
            set
            {
                _pageIsBusy = value;
                NotifyPropertyChanged(nameof(PageIsBusy));
            }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        #endregion

        #region Dependancies

        IConnectivity _connectivity;

        #endregion

        public BaseViewModel(IConnectivity connectivity = null)
        {
            //Initializing dependencies
            _connectivity = (connectivity == null) ? new Connectivity() : connectivity;
        }

        //Requires including LoaderCustomControl in the View to work.
        protected void ChangeBusyStatus(bool busy, string message = null)
        {
            PageIsBusyMessage = message ?? "";
            PageIsBusy = busy;
        }

        //Checking internet connection from any ViewModel.
        public async Task<bool> ConnectionAvailable()
        {
            if (!_connectivity.IsConnected())
            {
                await ShowAlertMessage("Error", "No internet connection", "Okay");
                return false;
            }
            return true;
        }

        public virtual Task OnViewAppearing()
        {
            return Task.FromResult<object>(null);
        }

        public virtual Task OnViewDisappearing()
        {
            return Task.FromResult<object>(null);
        }

        public virtual bool OnNativeBackPressed()
        {
            return false;
        }

        //Wiring View and ViewModel.
        public static void WireViewModel(IContentPage view, BaseViewModel viewModel)
        {
            view.BindingContext = viewModel;
            view.OnViewAppearing = viewModel.OnViewAppearing;
            view.OnViewDisappearing = viewModel.OnViewDisappearing;
            view.OnNativeBackPressed = viewModel.OnNativeBackPressed;

            viewModel.ShowAlertMessage = view.DisplayAlert;
            viewModel.ShowAlertMessageResponse = view.DisplayAlert;
            viewModel.Navigation = view.Navigation;
        }
    }
}
