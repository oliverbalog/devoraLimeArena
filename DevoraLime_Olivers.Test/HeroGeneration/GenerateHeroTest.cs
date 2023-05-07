using DevoraLime_Olivers.Domain.Modules.Arena;
using DevoraLime_Olivers.Domain.Modules.Arena.Commands;
using DevoraLime_Olivers.Domain.Modules.Arena.Queries;
using DevoraLime_Olivers.Infrastructure.ArenaService;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevoraLime_Olivers.Test.HeroGeneration
{
    public class GenerateHeroTest
    {
        public static IHostBuilder CreateHostBuilder() =>
    Host.CreateDefaultBuilder()
        .ConfigureServices((hostingContext, services) =>
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(StartArena.Handler).Assembly))
        .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ArenaService).Assembly))
        .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GenerateHeroTest).Assembly))
        .AddSingleton<IArenaService, ArenaService>();
        });

        [Fact]
        public async void TestHeroGenerator()
        {
            var host = CreateHostBuilder().Build();
            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var count = 5;

            var heroes = await services.GetService<IMediator>().Send(new GetHeroes.Query(count));

            Assert.True(heroes.Count == count);
        }




    }
}
