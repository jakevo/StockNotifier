using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockNotifier.Application;
using StockNotifier.DepencyInjection;

namespace StockNotifier
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Starting service.....");
            var serviceProvider = StockNotifierServiceProviderFactory.Create();
            var useCase = serviceProvider.GetRequiredService<IUseCase>();
            useCase.Execute();

            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //var request = new TwilioAuthenticationModel("", "");
                //await Authenticate();
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
