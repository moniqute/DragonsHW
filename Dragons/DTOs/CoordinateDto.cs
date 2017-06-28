using System;
using System.Xml.Serialization;

namespace DragonsOfMugloar.DTOs
{
    [Serializable]
    public class CoordinateDto
    {
        [XmlElement("x")]
        public string X { get; set; }

        [XmlElement("y")]
        public string Y { get; set; }

        [XmlElement("z")]
        public string Z { get; set; }
    }
}