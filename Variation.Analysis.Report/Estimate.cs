using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents an Estimate node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class Estimate : IXmlSerializable
    {
        public double PercentLowLimit { get; set; }
        public double PercentHighLimit { get; set; }
        public double PercentOutSpec { get; set; }
        public double Low { get; set; }
        public double High { get; set; }
        public double Range { get; set; }
        public string SigmaLevel { get; set; } = "*+/- 3 Sigma Range : 99.7300%";

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Estimate")
            {
                PercentLowLimit = double.TryParse(reader.GetAttribute("perLowLimit"), out double percentLowLimit)
                    ? percentLowLimit
                    : default;
                PercentHighLimit = double.TryParse(reader.GetAttribute("perHighLimit"), out double percentHighLimit)
                    ? percentHighLimit
                    : default;
                PercentOutSpec = double.TryParse(reader.GetAttribute("perOutSpec"), out double percentOutSpec)
                    ? percentOutSpec
                    : default;
                Low = double.TryParse(reader.GetAttribute("low"), out double low) ? low : default;
                High = double.TryParse(reader.GetAttribute("high"), out double high) ? high : default;
                Range = double.TryParse(reader.GetAttribute("range"), out double range) ? range : default;
                SigmaLevel = reader.GetAttribute("sigmaLevel");
            }

            _ = reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("perLowLimit", PercentLowLimit.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("perHighLimit", PercentHighLimit.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("perOutSpec", PercentOutSpec.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("low", Low.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("high", High.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("range", Range.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("sigmaLevel", SigmaLevel);
        }
    }
}
