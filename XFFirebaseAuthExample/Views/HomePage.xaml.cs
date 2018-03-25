using Autofac;
using Xamarin.Forms;
using XFFirebaseAuthExample.ViewModels;

namespace XFFirebaseAuthExample.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<HomeViewModel>();
        }
    }
}
