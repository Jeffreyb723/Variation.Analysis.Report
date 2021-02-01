using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a Label node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class Label : IXmlSerializable
    {
        public string LabelAttribute { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public List<Leader> Leaders { get; set; } = new List<Leader>();

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Label")
            {
                LabelAttribute = reader.GetAttribute("label");
                X = double.TryParse(reader.GetAttribute("x"), out double x) ? x : default;
                Y = double.TryParse(reader.GetAttribute("y"), out double y) ? y : default;
            }

            _ = reader.Read();

            while (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Leader")
            {
                Leader leader = new Leader();
                leader.ReadXml(reader);

                Leaders.Add(leader);
            }

            _ = reader.Read();
            
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("label", LabelAttribute);
            writer.WriteAttributeString("x", X.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("y", Y.ToString(CultureInfo.InvariantCulture));

            foreach (Leader leader in Leaders)
            {
                writer.WriteStartElement("Leader");
                leader.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
}
