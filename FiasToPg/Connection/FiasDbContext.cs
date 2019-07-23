using System.Collections.Generic;
using System.Data;
using FiasToPg.Parse.ModelMetadata;
using FiasToPg.Settings;
using Microsoft.EntityFrameworkCore;

namespace FiasToPg.Connection
{
    public sealed class FiasDbContext : DbContext
    {
        private const string IdPropertyName = "__ID";

        private readonly CommonSettings _settings;
        private readonly IEnumerable<IModelDescription> _modelDescriptions;

        public FiasDbContext(CommonSettings settings, IEnumerable<IModelDescription> modelDescriptions)
        {
            _settings = settings;
            _modelDescriptions = modelDescriptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(_settings.ConnectionString, builder => builder.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var modelDescription in _modelDescriptions)
            {
                var entity = modelBuilder.Entity(modelDescription.Type);

                entity.ToTable(modelDescription.Table)
                    .Ignore(nameof(DataRow.ItemArray))
                    .Ignore(nameof(DataRow.RowError));

                entity.Property<long>(IdPropertyName);
                entity.HasKey(IdPropertyName);
            }
        }

    }
}
