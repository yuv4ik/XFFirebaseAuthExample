using Autofac;
using Xamarin.Forms;
using XFFirebaseAuthExample.ViewModels;

namespace XFFirebaseAuthExample.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<LoginViewModel>();
        }
    }
}
