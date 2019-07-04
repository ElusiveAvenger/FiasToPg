using System.Collections.Generic;
using System.Linq;

namespace FiasToPg.Parse.ModelMetadata
{
    public class ModelDescriptionFactory : IModelDescriptionFactory
    {
        private readonly IEnumerable<IModelDescription> _modelDescriptions;

        public ModelDescriptionFactory(IEnumerable<IModelDescription> modelDescriptions)
        {
            _modelDescriptions = modelDescriptions;
        }

        public IModelDescription GetFor(string fileName)
        {
            return _modelDescriptions.FirstOrDefault(description => fileName.Contains($"AS_{description.Table}_"));
        }

        public IEnumerable<IModelDescription> GetAll()
        {
            return _modelDescriptions;
        }
    }
}
