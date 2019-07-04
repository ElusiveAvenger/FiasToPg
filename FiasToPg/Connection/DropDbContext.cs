using FiasToPg.Settings;
using Microsoft.EntityFrameworkCore;

namespace FiasToPg.Connection
{
    public class DropDbContext : DbContext
    {
        private readonly CommonSettings _settings;

        public DropDbContext(CommonSettings settings)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(_settings.ConnectionString);
        }
    }
}
