using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace NXMLFormatter
{
    public class Formatter
    {
        private static readonly XmlWriterSettings settings = new XmlWriterSettings()
        {
            OmitXmlDeclaration = true,
            Indent = true,
            NewLineOnAttributes = true
        };

        public static string Format(string source, XmlWriterSettings customSettings = null)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(source);

            using (var xmlWriter = XmlWriter.Create(stringBuilder, customSettings ?? settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }
    }
}
