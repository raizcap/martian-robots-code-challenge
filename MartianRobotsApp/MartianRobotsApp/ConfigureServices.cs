using System;
using MartianRobotsApp.Communication;
using MartianRobotsApp.Services;
using MartianRobotsApp.Services.Instructions;
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
            services.AddSingleton<IRobotsConnector, RobotsConnector>();
            services.AddSingleton<IRobotInstructionsManagerService, RobotInstructionsManagerService>();
            services.AddSingleton<IMarsSurfaceService, MarsSurfaceService>();
            services.AddSingleton<IFileContentManagerService, FileContentManagerService>();
            services.AddSingleton<IInstructionsService, InstructionsService>();
            services.AddSingleton<IFileReaderService, FileReaderService>();

            RegisterInstructions(services);

            services.AddSingleton<IRobotsService, RobotsService>();
            services.AddSingleton<ISurfacesConnector, SurfacesConnector>();

            services.AddTransient<IHttpClientService, HttpClientService>();

        }

        private static void RegisterInstructions(IServiceCollection services)
        {
            services.AddSingleton<IForwardInstruction, ForwardInstruction>();
            services.AddSingleton<ILeftInstruction, LeftInstruction>();
            services.AddSingleton<IRightInstruction, RightInstruction>();
        }
    }
}

