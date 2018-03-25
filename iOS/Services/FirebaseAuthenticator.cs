using System.Threading.Tasks;
using Firebase.Auth;
using XFFirebaseAuthExample.Services;

namespace XFFirebaseAuthExample.iOS.Services
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await Auth.DefaultInstance.SignInAsync(email, password);
            return await user.GetIdTokenAsync();
        }
    }
}
