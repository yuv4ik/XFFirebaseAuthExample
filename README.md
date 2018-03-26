## XFFirebaseAuthExample
Is an example of Xamarin.Forms `Droid` & `iOS` application that authenticates users via `Firebase` and consuming a protected .NET Core WEB API backend with `Firebase` OAuthToken.

Beside that you will also find examples of:
* IOC using Autofac
* PropertyChanged.Fody
* Input validation
* IValueConverter
* Dynamically enable/disable `Command` with `ChangeCanExecute`
* Styles

## Firebase

### Service Configuration

* [Sign-in](https://console.firebase.google.com/u/1/) and navigate to console
* Create a new project
    * Add application for Android
        * Download google-services.json
    * Add application for iOs
        * Download GoogleService-Info.plist 
* Open Authentication section
    * Switch to "Sign-in method" tab
        * Enable "Email/Password"
    * Switch to "Users" tab
        * Add new user

### .NET Core WEB API Configuration

* In `Startup.ConfigureServices(..)` set the var `firebaseProjectId` to your firebase id project.
        
### Mobile App Configuration

#### Droid

* Add "Xamarin.Firebase.Auth" NuGet package
* Import "google-services.json" and set the building action to "GoogleServicesJson"
   * In other words the `.csproj` should contain the next line: <GoogleServicesJson Include="google-services.json" />
* Make sure that your package name is identical to the package name inside "google-services.json"
* Add the next line of code in the MainActivity.cs OnCreate before LoadApplication:  
```C#
FirebaseApp.InitializeApp(Application.Context);
```  
* Implement IFirebaseAuthenticator

#### iOS
* Add "Xamarin.Firebase.iOS.Auth" NuGet package to iOS project
* Import "GoogleService-Info.plist" and set the building action to "BundleResource"
* Make sure that your bundle identifier is identical to the bundle identifier inside "GoogleService-Info.plist"
* Add the next line of code in the AppDelegate.cs FinishedLaunching before LoadApplication:  
```C#
Firebase.Core.App.Configure();
```  
* Implement IFirebaseAuthenticator
* Please note that if you want to test on the iOS simulator you will have to do one extra step as described [here](https://stackoverflow.com/a/39488013/1970317) due to a bug.
