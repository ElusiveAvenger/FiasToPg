using System.Threading.Tasks;

namespace FiasToPg.Parse
{
    public interface IDataReader
    {
        Task Execute(string fileName);
    }
}