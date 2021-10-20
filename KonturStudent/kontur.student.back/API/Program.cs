using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using API.Houston;
using Vostok.Hosting;
using Vostok.Hosting.Houston.Abstractions;
using Vostok.Hosting.Setup;
using Vostok.Hosting.Houston;

[assembly: HoustonEntryPoint(typeof(Application))]


namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new HoustonHost(args, config =>
            {
                config.InHouston.SetupEnvironment(EnvironmentSetup);
            });

            await host.WithConsoleCancellation().RunAsync();
        }

        private static void EnvironmentSetup(IVostokHostingEnvironmentBuilder builder)
        {
            builder
                .SetupApplicationIdentity(identityBuilder => identityBuilder
                    .SetProject("API")
                    .SetApplication("kontur.student.back")
                    .SetEnvironment("Dev"))
                .SetupLog(logBuilder => logBuilder
                    .SetupConsoleLog())
                .SetPort(1234);
        }
    }
}
