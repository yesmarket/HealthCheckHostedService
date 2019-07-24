using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace HealthCheckHostedService
{
    public class HealthCheckHostedService : IHostedService
    {
        private readonly HealthCheckService _healthCheckService;
        private readonly int _port;
        private readonly string _url;
        private HealthCheckServer _healthCheckServer;

        public HealthCheckHostedService(
            int port,
            string url,
            HealthCheckService healthCheckService)
        {
            _port = port;
            _url = url;
            _healthCheckService = healthCheckService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.Out.WriteLine("Starting health-check server...");
            _healthCheckServer = new HealthCheckServer(_port, _healthCheckService, _url);
            _healthCheckServer.Start();
            Console.Out.WriteLine("Health-check server started");

            await Task.FromResult(true);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.Out.WriteLine("Stopping metrics server...");
            await _healthCheckServer.StopAsync();
            Console.Out.WriteLine("Metrics server stopped");
        }
    }
}