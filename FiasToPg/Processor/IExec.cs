using System.Threading.Tasks;

namespace FiasToPg.Processor
{
    public interface IExec
    {
        Task Run();
    }
}
