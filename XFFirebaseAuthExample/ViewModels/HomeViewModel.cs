using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFFirebaseAuthExample.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand MakeApiRequestCmd { get; }

        public string RemoteData { get; private set; }

        Action propChangedCallBack => (MakeApiRequestCmd as Command).ChangeCanExecute;

        public HomeViewModel()
        {
            MakeApiRequestCmd = new Command<bool>(async (authorized) => await MakeApiRequest(authorized), _ => !IsBusy);
        }

        // Without provided token a 401 will be returned
        async Task MakeApiRequest(bool authorized)
        {
            try
            {
                IsBusy = true;
                propChangedCallBack();

                RemoteData = string.Empty;

                using (var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(3) })
                {
                    if (authorized)
                    {
                        var authValue = new AuthenticationHeaderValue("Bearer", (Application.Current as App).AuthToken);
                        httpClient.DefaultRequestHeaders.Authorization = authValue;
                    }

                    var apiUrl = GetApiUrl();
                    var res = await httpClient.GetAsync($"{apiUrl}:5001/api/data");
                    var content = await res.Content.ReadAsStringAsync();

                    RemoteData = $"StatusCode: {res.StatusCode}, Content: {content}";
                }
            }
            catch(Exception ex)
            {
                RemoteData = $"Exception: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
                propChangedCallBack();
            }

        }

        // https://smellyc0de.wordpress.com/2018/03/03/how-to-access-localhost-from-android-emulator-and-ios-simulator/
        string GetApiUrl()
        {
            string apiUrl = null;
            if (Device.RuntimePlatform == Device.Android)
                return "http://10.0.2.2";
            else if (Device.RuntimePlatform == Device.iOS)
                return "http://localhost";
            else throw new NotSupportedException("Platform is not supported.");
        }
    }
}
