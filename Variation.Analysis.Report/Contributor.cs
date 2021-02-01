using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a Contributor node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class Contributor : IXmlSerializable
    {
        public string Name { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string PartName { get; set; }
        public string FeatureName { get; set; }
        public double ToleranceValue { get; set; }
        public double ToleranceEffective { get; set; }
        public double Effect { get; set; }
        public double Sensitivity { get; set; }
        public double MeanShift { get; set; }
        public string Src { get; set; }
        public double Weight { get; set; }

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Contributor")
            {
                Name = reader.GetAttribute("name");
                Description1 = reader.GetAttribute("desc1");
                Description2 = reader.GetAttribute("desc2");
                PartName = reader.GetAttribute("partName");
                FeatureName = reader.GetAttribute("featureName");
                ToleranceValue = double.TryParse(reader.GetAttribute("toleranceValue"), out double toleranceValue)
                    ? toleranceValue
                    : default;
                ToleranceEffective =
                    double.TryParse(reader.GetAttribute("toleranceEffective"), out double toleranceEffective)
                        ? toleranceEffective
                        : default;
                Effect = double.TryParse(reader.GetAttribute("effect"), out double effect) ? effect : default;
                Sensitivity = double.TryParse(reader.GetAttribute("sensitivity"), out double sensitivity)
                    ? sensitivity
                    : default;
                MeanShift = double.TryParse(reader.GetAttribute("meanShift"), out double meanShift)
                    ? meanShift
                    : default;
                Src = reader.GetAttribute("src");
                Weight = double.TryParse(reader.GetAttribute("weight"), out double weight) ? weight : default;
            }

            _ = reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("desc1", Description1);
            writer.WriteAttributeString("desc2", Description2);
            writer.WriteAttributeString("partName", PartName);
            writer.WriteAttributeString("featureName", FeatureName);
            writer.WriteAttributeString("toleranceValue", ToleranceValue.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("toleranceEffective",
                ToleranceEffective.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("effect", Effect.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("sensitivity", Sensitivity.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("meanShift", MeanShift.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("src", Src);
            writer.WriteAttributeString("weight", Weight.ToString(CultureInfo.InvariantCulture));
        }
    }
}
