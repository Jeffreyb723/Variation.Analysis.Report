using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a Histogram node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class Histogram
    {
        [XmlElement("XAxis")] public Axis XAxis { get; set; }
        [XmlElement("YAxis")] public Axis YAxis { get; set; }
        [XmlElement("LeftTail")] public Curve LeftTail { get; set; }
        [XmlElement("Curve")] public Curve Curve { get; set; }
        [XmlElement("RightTail")] public Curve RightTail { get; set; }
        [XmlElement("Box")] public List<Box> Boxes { get; set; }
        [XmlElement("Label")] public List<Label> Labels { get; set; }
    }
}
