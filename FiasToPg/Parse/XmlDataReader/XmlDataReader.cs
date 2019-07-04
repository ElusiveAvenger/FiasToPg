using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace FiasToPg.Parse.XmlDataReader
{
    public class XmlDataReader : IXmlDataReader
    {
        private readonly string _uri;
        private readonly string _rootElementName;

        private readonly string _root;

        private readonly XmlReader _xmlReader;

        public XmlDataReader(string uri, string rootElementName)
        {
            _uri = uri;
            _rootElementName = rootElementName;

            FileStream fileStream = File.OpenRead(uri);
            BufferedStream bufferedStream = new BufferedStream(fileStream);

            _xmlReader = XmlReader.Create(bufferedStream);

            _xmlReader.MoveToContent();
            _xmlReader.MoveToElement();
            _root = _xmlReader.Name;
            _xmlReader.Read();
        }

        public void Dispose()
        {
            _xmlReader?.Dispose();
        }

        public IEnumerable<XNode> Get()
        {
            using (XmlReader xmlReader = XmlReader.Create(_uri))
            {

                xmlReader.MoveToContent();

                while (!xmlReader.EOF)
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == _root)
                    {
                        yield return XNode.ReadFrom(xmlReader);
                    }
                    else
                    {
                        xmlReader.Read();
                    }
                }
            }
        }

        public IEnumerable<XElement> GetElements()
        {
            using (XmlReader xmlReader = XmlReader.Create(_uri))
            {
                xmlReader.MoveToContent();

                while (!xmlReader.EOF)
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name != _root)
                    {
                        yield return XNode.ReadFrom(xmlReader) as XElement;
                    }
                    else
                    {
                        xmlReader.Read();
                    }
                }
            }
        }

        public string GetPart(int count)
        {
            var xml = new XElement(_root);

            var read = 0;

            while (read++ < count && NextElement(out var element))
            {
                xml.Add(element);
            }

            return xml.ToString();
        }

        private bool NextElement(out XElement element)
        {
            while (_xmlReader.NodeType != XmlNodeType.Element && !_xmlReader.EOF)
            {
                _xmlReader.Read();
            }

            if (_xmlReader.EOF)
            {
                element = null;
                return false;
            }

            element = XNode.ReadFrom(_xmlReader) as XElement;
            return true;
        }

        public bool CanRead => !_xmlReader.EOF;
    }
}
