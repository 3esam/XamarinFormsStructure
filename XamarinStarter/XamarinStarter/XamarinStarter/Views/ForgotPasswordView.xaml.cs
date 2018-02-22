using XamarinStarter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinStarter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPasswordView : BaseView
    {
		public ForgotPasswordView (object data)
		{
			InitializeComponent ();
            BaseViewModel.WireViewModel(this, new ForgotPasswordViewModel(data));
        }
    }
}