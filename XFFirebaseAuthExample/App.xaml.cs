using Autofac;
using Xamarin.Forms;
using XFFirebaseAuthExample.Services;
using XFFirebaseAuthExample.ViewModels;
using XFFirebaseAuthExample.Views;

namespace XFFirebaseAuthExample
{
    public partial class App : Application
    {
        public IContainer Container { get; }
        public string AuthToken { get; set; }

        public App(Module module)
        {
            InitializeComponent();
            Container = BuildContainer(module);
            MainPage = new NavigationPage(new LoginPage()); 
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        IContainer BuildContainer(Module module)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LoginViewModel>().AsSelf();
            builder.RegisterType<HomeViewModel>().AsSelf();
            builder.RegisterType<NavigationService>().AsSelf().SingleInstance();
            builder.RegisterModule(module);
            return builder.Build();
        }
    }
}
