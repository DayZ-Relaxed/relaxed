using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Relaxed.LogParser.Model;
using Relaxed.LogParser.Settings;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile("appsettings.Development.json", true, true)
        .Build();

    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton(new AppSettings(builder));
            services.AddOptions();
            services.AddDbContext<DayzRelaxedContext>(
                opt => opt.UseSqlServer(builder.GetConnectionString("DayZRelaxed"))
            );
            services.AddSingleton<App>();
        });
}
