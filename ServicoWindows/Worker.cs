using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServicoWindows.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ServicoWindows.Models;

namespace ServicoWindows
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IMailService _mailService;

        public Worker(
            MailService mailService, 
            ILogger<Worker> logger) => 
            (_mailService, _logger) = (mailService, logger);


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var requestEmail = new EmailRequest { ToEmail = "mariana.montenegro1989@gmail.com", Subject = "Serviço Startado", Body = "Texto teste" };
            _mailService.SendEmailAsync(requestEmail);

            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            var requestEmail = new EmailRequest { ToEmail = "mariana.montenegro1989@gmail.com", Subject = "Serviço Pausado", Body = "Texto teste" };
            _mailService.SendEmailAsync(requestEmail);

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var requestEmail = new EmailRequest { ToEmail = "mariana.montenegro1989@gmail.com", Subject="Serviço em Execução", Body ="Texto teste"};
                    await _mailService.SendEmailAsync(requestEmail);
                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);
                Environment.Exit(1);
            }


        }
    }
}
