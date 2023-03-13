using MartianRobotsApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
    .ConfigureServices(ConfigureServices.CreateDependencyInjection)
    .ConfigureServices(services => services.AddSingleton<MartianRobots>())
    .Build()
    .Services
    .GetService<MartianRobots>()
    .Run(args);
