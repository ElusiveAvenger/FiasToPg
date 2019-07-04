using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FiasToPg.Settings;
using Microsoft.Extensions.Logging;

namespace FiasToPg.Parse
{
    public class FileProvider : IFileProvider
    {
        private readonly ILogger<FileProvider> _logger;
        private readonly CommonSettings _settings;

        public FileProvider(ILogger<FileProvider> logger, CommonSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public IEnumerable<string> List()
        {
            try
            {
                var files = Directory.GetFiles(_settings.DataPath, _settings.FileMask);

                return files;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Enumerable.Empty<string>();
            }
        }
    }
}
