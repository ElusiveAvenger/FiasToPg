using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace FiasToPg.Parse
{
    public class SchemeProvider : ISchemeProvider
    {
        private const string SchemeDir = "./DataModels/OriginXSD";
        private readonly ILogger<SchemeProvider> _logger;

        public SchemeProvider(ILogger<SchemeProvider> logger)
        {
            _logger = logger;
        }

        public string GetFor(string xsd)
        {
            var schemas = Directory.GetFiles($"{SchemeDir}", $"AS_{xsd}_*.xsd");

            if (schemas.Length > 1)
            {
                _logger.LogError($"found more than one schema for {xsd}");
                return string.Empty;
            }

            return schemas.FirstOrDefault();
        }
    }
}
