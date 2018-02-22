using XamarinStarter.Abstractions;
using XamarinStarter.Helpers;
using XamarinStarter.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinStarter.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }

        #endregion

        #region properties

        private string _username;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyPropertyChanged(nameof(Username));
                NotifyCanExecuteCommand(LoginCommand);
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged(nameof(Password));
                NotifyCanExecuteCommand(LoginCommand);
            }
        }

        #endregion

        #region Dependencies

        IPersistantKeyData _persistantKeyData;

        #endregion

        //Optional parameter to inject dependencies via constructor.
        public LoginViewModel(IPersistantKeyData presistantKeyData = null)
        {
            //Initializing dependencies
            _persistantKeyData = (presistantKeyData == null) ? new PersistantKeyData() : presistantKeyData;

            SetupCommands();
        }

        private void SetupCommands()
        {
            LoginCommand = new Command(Login, CanLogin);

            ForgotPasswordCommand = new Command(async () =>
            {
                await Navigation.PushModalAsync(new ForgotPasswordView(Username));
            });

#if __DEBUG__
            InitializeDebugProperties();
#endif
        }

        private void InitializeDebugProperties()
        {
            Username = "user@company.com";
            //Password = "1234";
        }
        
        private bool CanLogin()
        {
            return
                !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private async void Login()
        {
            ChangeBusyStatus(true, "Fake Loading..");

            await Task.Delay(1000);

            ChangeBusyStatus(false);
        }
    }
}
