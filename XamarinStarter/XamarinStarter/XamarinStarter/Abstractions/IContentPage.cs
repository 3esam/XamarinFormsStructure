using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinStarter.Abstractions
{
    public interface IContentPage
    {
        object BindingContext { get; set; }
        INavigation Navigation { get; }
        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
        Func<Task> OnViewAppearing { get; set; }
        Func<Task> OnViewDisappearing { get; set; }
        Func<bool> OnNativeBackPressed { get; set; }
    }
}
