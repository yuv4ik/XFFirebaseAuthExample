using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFFirebaseAuthExample.Services;
using XFFirebaseAuthExample.Views;

namespace XFFirebaseAuthExample.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ValidatableObject<string> Email { get; }
        public ValidatableObject<string> Password { get; }
        public ICommand LoginCmd { get; }

        readonly IFirebaseAuthenticator firebaseAuthenticator;
        readonly NavigationService navigationService;

        Action propChangedCallBack => (LoginCmd as Command).ChangeCanExecute;

        public LoginViewModel(
            IFirebaseAuthenticator firebaseAuthenticator,
            NavigationService navigationService)
        {
            this.firebaseAuthenticator = firebaseAuthenticator;
            this.navigationService = navigationService;

            LoginCmd = new Command(async () => await Login(), () => Email.IsValid && Password.IsValid && !IsBusy);

            Email = new ValidatableObject<string>(propChangedCallBack, new EmailValidator()) { Value = "myuser@service.com" };
            Password = new ValidatableObject<string>(propChangedCallBack, new PasswordValidator()) { Value = "Qwerty123" };
        }

        async Task Login()
        {
            IsBusy = true;
            propChangedCallBack();
            (Application.Current as App).AuthToken = await firebaseAuthenticator.LoginWithEmailPassword(Email.Value, Password.Value);
            await navigationService.PushAsync(new HomePage());
            IsBusy = false;
            propChangedCallBack();
        }
    }
}
