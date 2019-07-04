using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FiasToPg.Connection;
using FiasToPg.Parse;
using FiasToPg.Settings;
using Microsoft.Extensions.Logging;

namespace FiasToPg.Processor
{
    public class Exec : IExec
    {
        private readonly CommonSettings _settings;
        private readonly IFileProvider _fileProvider;
        private readonly IDataReader _dataReader;
        private readonly ILogger<Exec> _logger;
        private readonly IDbContextBuilder _dbContextBuilder;

        public Exec(CommonSettings settings,
            ILogger<Exec> logger,
            IFileProvider fileProvider,
            IDataReader dataReader,
            IDbContextBuilder dbContextBuilder)
        {
            _settings = settings;
            _logger = logger;
            _fileProvider = fileProvider;
            _dataReader = dataReader;
            _dbContextBuilder = dbContextBuilder;
        }

        public async Task Run()
        {
            var watch = Stopwatch.StartNew();
            try
            {
                var files = _fileProvider.List().ToList();

                if (!files.Any())
                {
                    _logger.LogWarning("No files found to process.");
                    return;
                }

                using (var context = _dbContextBuilder.BuildForAll())
                {
                    if (_settings.Drop)
                    {
                        _logger.LogWarning("DataBase will be dropped");

                        await context.Database.EnsureDeletedAsync();
                    }

                    await context.Database.EnsureCreatedAsync();
                }

                foreach (var file in files)
                {
                    await _dataReader.Execute(file);
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
            }
            finally
            {
                watch.Stop();
                _logger.LogInformation($"processing complete in {new DateTime(watch.ElapsedTicks) - new DateTime()}");
            }

        }
    }
}
