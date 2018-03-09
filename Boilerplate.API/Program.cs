using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Boilerplate.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .Run();
        }

        // This method is called by the "dotnet ef" CLI tools
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSetting("EFToolBeingUsed", "true")
                .Build();
    }
}
