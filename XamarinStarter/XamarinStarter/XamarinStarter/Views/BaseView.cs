using XamarinStarter.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinStarter.Views
{
    public class BaseView : ContentPage, IContentPage
    {
        INavigation IContentPage.Navigation => this.Navigation;
        public Func<Task> OnViewAppearing { get; set; }
        public Func<Task> OnViewDisappearing { get; set; }
        public Func<bool> OnNativeBackPressed { get; set; }

        protected override async void OnAppearing()
        {
            await OnViewAppearing?.Invoke();
        }

        protected override async void OnDisappearing()
        {
            await OnViewDisappearing?.Invoke();
        }

        protected override bool OnBackButtonPressed()
        {
            if (OnNativeBackPressed != null)
                return OnNativeBackPressed();
            return base.OnBackButtonPressed();
        }
    }
}
