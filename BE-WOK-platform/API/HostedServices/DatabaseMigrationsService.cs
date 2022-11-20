using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API.HostedServices
{
    public class DatabaseMigrationsService : IHostedService, IDisposable
    {
        private readonly ILogger<DatabaseMigrationsService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public DatabaseMigrationsService(
            ILogger<DatabaseMigrationsService> logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                await scope.ServiceProvider
                    .GetRequiredService<AppDbContext>()
                    .Database
                    .MigrateAsync(cancellationToken);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
