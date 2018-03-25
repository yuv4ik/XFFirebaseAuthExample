using System.Threading.Tasks;

namespace XFFirebaseAuthExample.Services
{
    public interface IFirebaseAuthenticator
    {
        /// <summary>
        /// Login with email and password.
        /// </summary>
        /// <returns>OAuth token</returns>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}
