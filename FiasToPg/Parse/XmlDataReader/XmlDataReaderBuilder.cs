using System.Data;
using FiasToPg.Parse.ModelMetadata;
using Microsoft.Extensions.Logging;

namespace FiasToPg.Parse.XmlDataReader
{
    public class XmlDataReaderBuilder : IXmlDataReaderBuilder
    {
        private readonly ILogger<XmlDataReaderBuilder> _logger;

        public XmlDataReaderBuilder(ILogger<XmlDataReaderBuilder> logger)
        {
            _logger = logger;
        }

        public IXmlDataReader BuildFor(IModelDescription model, string uri)
        {
            if (model.Type.BaseType != typeof(DataRow))
            {
                _logger.LogWarning($"{model.Type.Name} does not implement {typeof(DataRow).Name}");
            }

            return new XmlDataReader(uri, model.DataSetType.Name);
        }
    }
}
