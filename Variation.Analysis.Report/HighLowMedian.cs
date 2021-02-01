using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a HighLowMedian node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class HighLowMedian : IXmlSerializable
    {
        public double ProcessVariance { get; set; }
        public double HlmVariance { get; set; }
        public double Nominal { get; set; }
        public double CutOffValue { get; set; }
        public double AdditionalContributors { get; set; }
        public double SumPercent { get; set; }
        public double RemainingPercent { get; set; }
        public List<Contributor> Contributors { get; set; } = new List<Contributor>();

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "HighLowMedian")
            {
                ProcessVariance = double.TryParse(reader.GetAttribute("processVariance"), out double processVariance)
                    ? processVariance
                    : default;
                HlmVariance = double.TryParse(reader.GetAttribute("hlmVariance"), out double hlmVariance)
                    ? hlmVariance
                    : default;
                Nominal = double.TryParse(reader.GetAttribute("nominal"), out double nominal) ? nominal : default;
                CutOffValue = double.TryParse(reader.GetAttribute("cutOffValue"), out double cutOffValue)
                    ? cutOffValue
                    : default;
                AdditionalContributors =
                    double.TryParse(reader.GetAttribute("additionalContribs"), out double additionalContributors)
                        ? additionalContributors
                        : default;
                SumPercent = double.TryParse(reader.GetAttribute("sumPer"), out double sumPercent)
                    ? sumPercent
                    : default;
                RemainingPercent = double.TryParse(reader.GetAttribute("remPer"), out double remainingPercent)
                    ? remainingPercent
                    : default;
            }

            _ = reader.Read();

            while (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Contributor")
            {
                Contributor contributor = new Contributor();
                contributor.ReadXml(reader);

                Contributors.Add(contributor);
            }

            _ = reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("processVariance", ProcessVariance.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("hlmVariance", HlmVariance.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("nominal", Nominal.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("cutOffValue", CutOffValue.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("additionalContribs",
                AdditionalContributors.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("sumPer", SumPercent.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("remPer", RemainingPercent.ToString(CultureInfo.InvariantCulture));

            foreach (Contributor contributor in Contributors)
            {
                writer.WriteStartElement("Contributor");
                contributor.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
}
