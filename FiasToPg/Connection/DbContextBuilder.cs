using FiasToPg.Parse.ModelMetadata;
using FiasToPg.Settings;

namespace FiasToPg.Connection
{
    public class DbContextBuilder : IDbContextBuilder
    {
        private readonly CommonSettings _settings;
        private readonly IModelDescriptionFactory _modelDescriptionFactory;

        public DbContextBuilder(CommonSettings settings, IModelDescriptionFactory modelDescriptionFactory)
        {
            _settings = settings;
            _modelDescriptionFactory = modelDescriptionFactory;
        }

        public FiasDbContext BuildFor(IModelDescription modelDescription)
        {
            return new FiasDbContext(_settings, new[] { modelDescription });
        }

        public FiasDbContext BuildForAll()
        {
            return new FiasDbContext(_settings, _modelDescriptionFactory.GetAll());
        }
    }
}
