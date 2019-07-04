using System.Collections.Generic;

namespace FiasToPg.Parse
{
    public interface IFileProvider
    {
        IEnumerable<string> List();
    }
}
