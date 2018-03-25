using System;
using System.Threading.Tasks;
using Firebase.Auth;
using XFFirebaseAuthExample.Services;

namespace XFFirebaseAuthExample.Droid.Service
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }
    }
}
