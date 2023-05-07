using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using System.Reflection;
using DevoraLime_Olivers.Domain.Modules.Arena;
using DevoraLime_Olivers.Infrastructure;
using DevoraLime_Olivers.Domain.Modules.Arena.Commands;
using DevoraLime_Olivers.Infrastructure.ArenaService;

namespace DevoraLime_Olivers.DependecyInjection
{
    public static class DependencyInjection
    {

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(StartArena.Handler).Assembly))
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ArenaService).Assembly))
            .AddSingleton<IArenaService, ArenaService>()
            .AddSingleton<App>();
            });
    }
}

