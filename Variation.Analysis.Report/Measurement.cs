using System;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a Measurement node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class Measurement
    {
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("type")] public string Type { get; set; }
        [XmlAttribute("description")] public string Description { get; set; }
        [XmlAttribute("objectPartName")] public string ObjectPartName { get; set; }
        [XmlAttribute("targetPartName")] public string TargetPartName { get; set; }
        [XmlAttribute("objectFeatureName")] public string ObjectFeatureName { get; set; }
        [XmlAttribute("targetFeatureName")] public string TargetFeatureName { get; set; }
        [XmlAttribute("src")] public string Src { get; set; }

        [XmlElement("Process")] public Process Process { get; set; }
        [XmlElement("Histogram")] public Histogram Histogram { get; set; }
        [XmlElement("HighLowMedian")] public HighLowMedian HighLowMedian { get; set; }
        [XmlElement("MeanShiftContributors")] public MeanShiftContributors MeanShiftContributors { get; set; }

        [XmlElement("VisVector")] public string VisVector { get; set; }
    }
}
