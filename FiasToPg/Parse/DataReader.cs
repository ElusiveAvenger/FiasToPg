using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using FiasToPg.Connection;
using FiasToPg.Parse.ModelMetadata;
using FiasToPg.Parse.XmlDataReader;
using FiasToPg.Settings;
using Microsoft.Extensions.Logging;

namespace FiasToPg.Parse
{
    public class DataReader : IDataReader
    {
        private readonly IModelDescriptionFactory _modelDescriptionFactory;
        private readonly ILogger<DataReader> _logger;
        private readonly CommonSettings _settings;
        private readonly IXmlDataReaderBuilder _xmlDataReaderBuilder;
        private readonly IDbContextBuilder _dbContextBuilder;

        public DataReader(IModelDescriptionFactory modelDescriptionFactory,
            ILogger<DataReader> logger,
            CommonSettings settings,
            IXmlDataReaderBuilder xmlDataReaderBuilder,
            IDbContextBuilder dbContextBuilder)
        {
            _modelDescriptionFactory = modelDescriptionFactory;
            _logger = logger;
            _settings = settings;
            _xmlDataReaderBuilder = xmlDataReaderBuilder;
            _dbContextBuilder = dbContextBuilder;
        }

        public async Task Execute(string fileName)
        {
            var modelDescription = _modelDescriptionFactory.GetFor(fileName);

            if (modelDescription == null)
            {
                _logger.LogWarning($"Could not find description for {fileName}");
                return;
            }

            _logger.LogInformation($"start reading file {fileName}");

            using (var reader = _xmlDataReaderBuilder.BuildFor(modelDescription, fileName))
            {
                var totalWatch = Stopwatch.StartNew();
                var totalCount = 0;

                var partCount = 0;

                while (reader.CanRead)
                {
                    var result = reader.GetPart(_settings.TransactionSize);
                    using (var dataSet = modelDescription.BuildDataSet())
                    {
                        dataSet.ReadXml(new StringReader(result));

                        using (var context = _dbContextBuilder.BuildFor(modelDescription))
                        {
                            foreach (DataTable dataSetTable in dataSet.Tables)
                            {
                                await context.AddRangeAsync(dataSetTable.AsEnumerable());
                            }

                            _logger.LogDebug("begin save...");
                            var count = await context.SaveChangesAsync();
                            totalCount += count;
                            partCount += count;
                            _logger.LogInformation($"save {count} (total: {totalCount})");
                        }
                    }

                    if (partCount >= _settings.PartCount && _settings.WaitBetweenPart > 0)
                    {
                        _logger.LogInformation($"timeout between parts ({_settings.WaitBetweenPart})");
                        partCount = 0;
                        await Task.Delay(_settings.WaitBetweenPart);
                        _logger.LogDebug($"timeout complete");
                    }
                }

                totalWatch.Stop();

                _logger.LogInformation($"saved {totalCount} items in {new DateTime(totalWatch.ElapsedTicks) - new DateTime()}");
            }
        }
    }
}
