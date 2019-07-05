using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using Microsoft.Extensions.Logging;

namespace FiasToPg.Settings
{
    public class CommonSettings
    {
        [Option('c', "connectionString", Required = true, HelpText = "connection for PostgreSQL")]
        public string ConnectionString { get; set; }

        [Option('m', "fileMask", Required = false, Default = "*.XML", HelpText = "mask for select files")]
        public string FileMask { get; set; }

        [Option('d', "drop", Required = false, Default = false, HelpText = "drop DB if exist")]
        public bool Drop { get; set; }

        [Option("dataPath", Required = false, Default = "/data", HelpText = "path to data dir", Hidden = true)]
        public string DataPath { get; set; }

        [Option('t', "transaction", Required = false, Default = 10000, HelpText = "size of section of insert data")]
        public int TransactionSize { get; set; }

        [Option("partCount", Required = false, Default = 1000000, HelpText = "size of part", Hidden = true)]
        public int PartCount { get; set; }

        [Option("waitBetweenPart", Required = false, Default = 180000, HelpText = "timeout between parts in milliseconds", Hidden = true)]
        public int WaitBetweenPart { get; set; }

        [Option("logLevel", Required = false, Default = 2, HelpText = "LogLevel for process logging", Hidden = true)]
        public LogLevel LogLevel { get; set; }

        [Usage(ApplicationAlias = nameof(FiasToPg))]
        public static IEnumerable<Example> Examples =>
            new List<Example>
            {
                new Example(
                    "minimal success example",
                    new UnParserSettings{ PreferShortName = true},
                    new CommonSettings
                    {
                        ConnectionString = "Host=localhost;Database=my_dataBase;Username=postgres;Password=postgres"
                    })
            };
    }
}
