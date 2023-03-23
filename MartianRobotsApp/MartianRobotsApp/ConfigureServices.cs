﻿using System;
using MartianRobotsApp.Communication;
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
            services.AddSingleton<IMarsSurfaceService, MarsSurfaceService>();
            services.AddSingleton<IFileContentManagerService, FileContentManagerService>();
            services.AddSingleton<IRobotsService, RobotsService>();
            services.AddSingleton<ISurfacesConnector, SurfacesConnector>();
        }
    }
}
