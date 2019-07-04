using System.Collections.Generic;

namespace FiasToPg.Parse.ModelMetadata
{
    public interface IModelDescriptionFactory
    {
        IModelDescription GetFor(string fileName);

        IEnumerable<IModelDescription> GetAll();
    }
}
