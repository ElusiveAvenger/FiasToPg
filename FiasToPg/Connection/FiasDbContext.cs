using System.Collections.Generic;
using System.Data;
using FiasToPg.Extension;
using FiasToPg.Parse.ModelMetadata;
using FiasToPg.Settings;
using Microsoft.EntityFrameworkCore;

namespace FiasToPg.Connection
{
    public sealed class FiasDbContext : DbContext
    {
        private const string IdPropertyName = "EntityId";

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

                // TODO код ниже связан с проблемой Cuba Studio https://youtrack.cuba-platform.com/issue/STUDIO-6536
                // https://animesh.blog/ef-core-code-first-with-postgres/
                foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
                {
                    mutableEntityType.Relational().TableName = mutableEntityType.Relational().TableName.ToSnakeCase();

                    foreach (var property in mutableEntityType.GetProperties())
                        property.Relational().ColumnName = property.Name.ToSnakeCase();

                    foreach (var key in mutableEntityType.GetKeys())
                        key.Relational().Name = key.Relational().Name.ToSnakeCase();

                    foreach (var key in mutableEntityType.GetForeignKeys())
                        key.Relational().Name = key.Relational().Name.ToSnakeCase();

                    foreach (var index in mutableEntityType.GetIndexes())
                        index.Relational().Name = index.Relational().Name.ToSnakeCase();
                }
                // ------------------------------------------------------
            }
        }

    }
}
