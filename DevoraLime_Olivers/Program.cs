
using DevoraLime_Olivers;
using DevoraLime_Olivers.Domain.Modules.Arena.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static async Task Main(string[] args)
    {


        using IHost host = DevoraLime_Olivers.DependecyInjection.DependencyInjection.CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;

        try
        {
            services.GetRequiredService<App>().Run(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    

}