using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinStarter.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        #region Commands

        public ICommand BackButtonCommand { get; set; }

        public ICommand SendButtonCommand { get; set; }

        #endregion

        #region properties

        private string _uername;

        public string Username
        {
            get { return _uername; }
            set
            {
                _uername = value;
                NotifyPropertyChanged(nameof(_uername));
            }
        }

        #endregion

        public ForgotPasswordViewModel()
        {
            Title = "Forget password";
        }

        public ForgotPasswordViewModel(object data) : this()
        {
            if (data is string)
                Username = (string)data;

            SetupCommands();
        }

        private void SetupCommands()
        {
            BackButtonCommand = new Command(async () =>
            {
                await Navigation.PopModalAsync();
            });

            SendButtonCommand = new Command(async () =>
            {
                ChangeBusyStatus(true, "Waiting..");
                await Task.Delay(1000);
                await ShowAlertMessage("msg", "You've waited one second to see this messgae", "Okey :/");
                ChangeBusyStatus(false);
            });
        }

        public override bool OnNativeBackPressed()
        {
            Navigation.PopModalAsync();
            return true;
        }
    }
}
