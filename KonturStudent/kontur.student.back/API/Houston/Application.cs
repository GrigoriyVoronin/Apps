using System;
using System.Threading.Tasks;
using Vostok.Applications.AspNetCore;
using Vostok.Applications.AspNetCore.Builders;
using Vostok.Hosting.Abstractions;

namespace API.Houston
{
    public class Application : VostokAspNetCoreApplication<Startup>
    {
        public override void Setup(IVostokAspNetCoreApplicationBuilder builder, IVostokHostingEnvironment environment)
        {
            // Здесь можно настроить встроенные в шаблон middleware и IWebHostBuilder, зарегистрировать что-нибудь в DI-контейнер.
            // Этот метод вызывается ещё до работы Startup'а.
        }
 
        public override Task WarmupAsync(IVostokHostingEnvironment environment, IServiceProvider provider)
        {
            // Здесь можно проводить длительную инициализацию, "прогрев".
            // Этот метод вызывается, когда DI-контейнер уже собран, а HTTP-сервер запущен, но до регистрации в SD.
            return Task.CompletedTask;
        }
    }
}