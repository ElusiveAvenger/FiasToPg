using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FiasToPg.Parse.XmlDataReader
{
    public interface IXmlDataReader : IDisposable
    {
        IEnumerable<XElement> GetElements();

        string GetPart(int count);

        bool CanRead { get; }
    }
}
