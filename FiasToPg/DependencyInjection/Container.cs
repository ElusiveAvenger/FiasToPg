using System;
using FiasToPg.Connection;
using FiasToPg.Logging;
using FiasToPg.Parse;
using FiasToPg.Parse.ModelMetadata;
using FiasToPg.Parse.ModelMetadata.Implements;
using FiasToPg.Parse.XmlDataReader;
using FiasToPg.Processor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FiasToPg.DependencyInjection
{
    public class Container
    {
        private readonly IServiceProvider _serviceProvider;

        private Container(Action<IServiceCollection> inject)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            inject(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public static Container Build(Action<IServiceCollection> inject)
        {
            return new Container(inject);
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddLogging(builder => builder.AddConsoleLogger())
                .Configure<LoggerFilterOptions>(options =>
                    options.MinLevel = LogLevel.Information);

            serviceCollection.AddSingleton<IDbContextBuilder, DbContextBuilder>();

            serviceCollection
                .AddTransient<IExec, Exec>()
                .AddTransient<IFileProvider, FileProvider>()
                .AddTransient<ISchemeProvider, SchemeProvider>()
                .AddTransient<IDataReader, DataReader>()
                .AddTransient<IModelDescriptionFactory, ModelDescriptionFactory>()
                .AddTransient<IXmlDataReaderBuilder, XmlDataReaderBuilder>()
                ;

            serviceCollection
                .AddTransient<IModelDescription, ActStat>()
                .AddTransient<IModelDescription, AddrObj>()
                .AddTransient<IModelDescription, CenterSt>()
                .AddTransient<IModelDescription, CurentSt>()
                .AddTransient<IModelDescription, EstStat>()
                .AddTransient<IModelDescription, FlatType>()
                .AddTransient<IModelDescription, House>()
                .AddTransient<IModelDescription, HouseInt>()
                .AddTransient<IModelDescription, HstStat>()
                .AddTransient<IModelDescription, IntvStat>()
                .AddTransient<IModelDescription, LandMark>()
                .AddTransient<IModelDescription, NDocType>()
                .AddTransient<IModelDescription, NormDoc>()
                .AddTransient<IModelDescription, OperStat>()
                .AddTransient<IModelDescription, Room>()
                .AddTransient<IModelDescription, RoomType>()
                .AddTransient<IModelDescription, SocrBase>()
                .AddTransient<IModelDescription, Stead>()
                .AddTransient<IModelDescription, StrStat>()
                ;
        }
    }
}
