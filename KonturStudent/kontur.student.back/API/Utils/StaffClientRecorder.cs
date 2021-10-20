using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkbKontur.Staff.Integration.Client;
using SkbKontur.Staff.Integration.Client.Configuration;

namespace API.Utils
{
    public static class StaffClientRecorder
    {
        public static IServiceCollection AddStaffClient(this IServiceCollection services)
        {
            return services.AddScoped<IStaffClientContext, StaffClientContext>(serviceProvider =>
            {
                var staffConfig = serviceProvider
                    .GetService<IConfiguration>()
                    .GetSection("Staff")
                    .Get<StaffConfig>();
                var options = new StaffClientOptions(staffConfig.ClientId, staffConfig.ClientSecret);
                return new StaffClientContext(options);
            });
        }
    }
}