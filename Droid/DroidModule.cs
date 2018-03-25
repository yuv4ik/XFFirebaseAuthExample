using Autofac;
using XFFirebaseAuthExample.Droid.Service;
using XFFirebaseAuthExample.Services;

namespace XFFirebaseAuthExample.Droid
{
    public class DroidModule : Module
    {
		protected override void Load(ContainerBuilder builder)
		{
            builder.RegisterType<FirebaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
		}
	}
}
