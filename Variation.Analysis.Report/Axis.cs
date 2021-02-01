using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents an Axis node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class Axis
    {
        [XmlElement("Label")] public List<Label> Labels { get;  set; }
    }
}
