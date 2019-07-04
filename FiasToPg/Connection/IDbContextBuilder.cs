using FiasToPg.Parse.ModelMetadata;

namespace FiasToPg.Connection
{
    public interface IDbContextBuilder
    {
        FiasDbContext BuildFor(IModelDescription modelDescription);

        FiasDbContext BuildForAll();
    }
}
