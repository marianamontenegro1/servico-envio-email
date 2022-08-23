using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicoWindows.Models;
using ServicoWindows.Services;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ServicoWindows
{
    public class Program
    {       
        static async Task Main(string[] args)
        {
            // Acessa dados do appsettings.Development.json - Equivalente a injeção de depencia que tem por padrao no startup
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.Json", optional: true)
            .AddCommandLine(args)
            .Build();

            IHost host = Host.CreateDefaultBuilder(args)                     
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
                services.AddSingleton<MailService>();

                // Acrescenta dados na classe EmailSettings de acordo com a configuração do appsettings.Development.json
                services.Configure<EmailSettings>(config.GetSection("EmailSettings"));                
            }) 
            .Build();

            await host.RunAsync();
        }
    }
}
