using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a Process node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class Process : IXmlSerializable
    {
        public double Nominal { get; set; }
        public double Mean { get; set; }
        public double StandardDeviation { get; set; }
        public double LowerSpecLimit { get; set; }
        public double UpperSpecLimit { get; set; }
        public double Cp { get; set; }
        public double Cpk { get; set; }
        public string Distribution { get; set; }
        public double Skewness { get; set; }
        public double Kurtosis { get; set; }
        public int SampleSize { get; set; }
        public Sample Sample { get; set; }
        public Estimate Estimate { get; set; }

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Process")
            {
                Nominal = double.TryParse(reader.GetAttribute("nominal"), out double nominal) ? nominal : default;
                Mean = double.TryParse(reader.GetAttribute("mean"), out double mean) ? mean : default;
                StandardDeviation =
                    double.TryParse(reader.GetAttribute("standardDeviation"), out double standardDeviation)
                        ? standardDeviation
                        : default;
                LowerSpecLimit = double.TryParse(reader.GetAttribute("lowerSpecLimit"), out double lowerSpecLimit)
                    ? lowerSpecLimit
                    : default;
                UpperSpecLimit = double.TryParse(reader.GetAttribute("upperSpecLimit"), out double upperSpecLimit)
                    ? upperSpecLimit
                    : default;
                Cp = double.TryParse(reader.GetAttribute("cp"), out double cp) ? cp : default;
                Cpk = double.TryParse(reader.GetAttribute("cpk"), out double cpk) ? cpk : default;
                Distribution = reader.GetAttribute("distribution");
                Skewness = double.TryParse(reader.GetAttribute("skewness"), out double skewness) ? skewness : default;
                Kurtosis = double.TryParse(reader.GetAttribute("kurtosis"), out double kurtosis) ? kurtosis : default;
                SampleSize = int.TryParse(reader.GetAttribute("sampleSize"), out int sampleSize) ? sampleSize : default;
            }

            _ = reader.Read();

            while (reader.MoveToContent() == XmlNodeType.Element &&
                   (reader.LocalName == "Sample" || reader.LocalName == "Estimate"))
            {
                Sample = new Sample();
                Sample.ReadXml(reader);

                Estimate = new Estimate();
                Estimate.ReadXml(reader);
            }

            _ = reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("nominal", Nominal.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("mean", Mean.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("standardDeviation", StandardDeviation.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("lowerSpecLimit", LowerSpecLimit.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("upperSpecLimit", UpperSpecLimit.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("cp", Cp.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("cpk", Cpk.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("distribution", Distribution);
            writer.WriteAttributeString("skewness", Skewness.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("kurtosis", Kurtosis.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("sampleSize", SampleSize.ToString(CultureInfo.InvariantCulture));

            writer.WriteStartElement("Sample");
            Sample.WriteXml(writer);
            writer.WriteEndElement();

            writer.WriteStartElement("Estimate");
            Estimate.WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}
