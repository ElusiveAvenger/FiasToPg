using FiasToPg.Parse.ModelMetadata;

namespace FiasToPg.Parse.XmlDataReader
{
    public interface IXmlDataReaderBuilder
    {
        IXmlDataReader BuildFor(IModelDescription model, string uri);
    }
}
