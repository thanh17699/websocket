using Vidoc.Socket;
using Vidoc.Socket.Configs;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        var appConfig = config.GetSection("AppConfig").Get<AppConfig>();

        // singleton
        services.AddSingleton(appConfig);
        services.AddHostedService<Worker>();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();
