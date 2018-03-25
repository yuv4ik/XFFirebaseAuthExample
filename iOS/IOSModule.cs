using Autofac;
using XFFirebaseAuthExample.iOS.Services;
using XFFirebaseAuthExample.Services;

namespace XFFirebaseAuthExample.iOS
{
    public class IOSModule : Module
    {
		protected override void Load(ContainerBuilder builder)
		{
            builder.RegisterType<FirebaseAuthenticator>().As<IFirebaseAuthenticator>().SingleInstance();
		}
	}
}
