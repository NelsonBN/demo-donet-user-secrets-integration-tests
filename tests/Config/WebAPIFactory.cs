using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Demo.Tests.Config;

public class WebAPIFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseStartup<TEntryPoint>();
        builder.UseEnvironment(Environments.Staging);

        builder.ConfigureAppConfiguration(c => c.AddUserSecrets(Assembly.GetExecutingAssembly(), true));
    }
}
