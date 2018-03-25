using Foundation;
using UIKit;

namespace XFFirebaseAuthExample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            Firebase.Core.App.Configure();

            LoadApplication(new App(new IOSModule()));

            return base.FinishedLaunching(app, options);
        }
    }
}
