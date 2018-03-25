using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace XFFirebaseAuthExampleWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://127.0.0.1:5001/")
                .Build();
    }
}
