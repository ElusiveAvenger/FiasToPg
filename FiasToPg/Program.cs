using System.Threading.Tasks;
using CommandLine;
using FiasToPg.DependencyInjection;
using FiasToPg.Processor;
using FiasToPg.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace FiasToPg
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Container container = null;

            Parser.Default.ParseArguments<CommonSettings>(args)
                .WithParsed(settings =>
                {
                    container = Container.Build(collection => collection.AddSingleton(settings));
                });

            if (container != null)
            {
                await Task.WhenAll(container.Resolve<IExec>().Run());
            }
        }
    }
}
