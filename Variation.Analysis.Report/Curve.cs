using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Variation.Analysis.Report
{
    /// <summary>
    /// Represents a Curve node in the XML results from a Variation Analysis (VSA) Model.
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public class Curve : IXmlSerializable
    {
        private IList<Point> _path;

        public IEnumerable<Point> Path
        {
            get => _path;
            set => _path = value.ToList();
        }

        public int Color { get; set; }

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element &&
                (reader.LocalName == "Curve" || reader.LocalName == "LeftTail" || reader.LocalName == "RightTail"))
            {
                _path = new List<Point>();

                foreach (Match match in Regex.Matches(reader.GetAttribute("path") ?? "", @"(?<=[LM])[0-9]+\s[0-9]+"))
                {
                    string[] point = match.ToString().Split(' ');

                    _path.Add(new Point(
                        float.TryParse(point[0], out float x) ? x : default,
                        float.TryParse(point[1], out float y) ? y : default));
                }

                string[] rgb = reader.GetAttribute("color")?.Split(',') ?? new []{"0", "0", "0"};
                Color = Information.Rgb(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
            }

            _ = reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            string path = string.Empty;

            for (int i = 0; i < _path.Count - 1; i += 2)
            {
                path += $"M{_path[i].X} {_path[i].Y} L{_path[i + 1].X} {_path[i + 1].Y} ";
            }

            writer.WriteAttributeString("path", path.TrimEnd());

            byte[] rgb = BitConverter.GetBytes(Color);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(rgb);
            }

            string color = $"{rgb[0]},{rgb[1]},{rgb[2]}";

            writer.WriteAttributeString("color", color);
        }
    }
}
