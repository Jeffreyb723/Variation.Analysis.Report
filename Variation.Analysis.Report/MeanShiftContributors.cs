using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a MeanShiftContribs node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class MeanShiftContributors : IXmlSerializable
    {
        public double Nominal { get; set; }
        public double ProMeanShift { get; set; }
        public double HlmMeanShift { get; set; }
        public double CutOffValve { get; set; }
        public double AdditionalContributors { get; set; }
        public double SumPercent { get; set; }
        public double RemainingPercent { get; set; }

        public List<Contributor> Contributors { get; set; } = new List<Contributor>();

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "HighLowMedian")
            {
                Nominal = double.TryParse(reader.GetAttribute("nominal"), out double nominal) ? nominal : default;
                ProMeanShift = double.TryParse(reader.GetAttribute("proMeanShift"), out double proMeanShift)
                    ? proMeanShift
                    : default;
                HlmMeanShift = double.TryParse(reader.GetAttribute("hlmMeanShift"), out double hlmMeanShift)
                    ? hlmMeanShift
                    : default;
                CutOffValve = double.TryParse(reader.GetAttribute("cutOffValue"), out double cutOffValve)
                    ? cutOffValve
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
            writer.WriteAttributeString("nominal", Nominal.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("proMeanShift", ProMeanShift.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("hlmMeanShift", HlmMeanShift.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("cutOffValue", CutOffValve.ToString(CultureInfo.InvariantCulture));
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
