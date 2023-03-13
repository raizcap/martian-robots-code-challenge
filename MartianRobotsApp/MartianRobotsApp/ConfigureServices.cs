using System;
using MartianRobotsApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MartianRobotsApp
{
	public static class ConfigureServices
	{
		public static void CreateDependencyInjection(HostBuilderContext hostContext, IServiceCollection services)
		{
            services.AddSingleton<IFileCheckerService, FileCheckerService>();
            services.AddSingleton<IArgumentsCheckerService, ArgumentsCheckerService>();
        }
    }
}

