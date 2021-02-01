using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a VariationAnalysis node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    [XmlRoot(ElementName = "VariationAnalysis")]
    public class VariationAnalysis
    {
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("version")] public string Version { get; set; }

        [XmlElement("Measurement")] public List<Measurement> Measurements { get; set; }
    }
}
