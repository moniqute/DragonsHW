using System;
using System.Xml.Serialization;

namespace DragonsOfMugloar.DTOs
{
    [Serializable]
    [XmlRoot("report")]
    public class ReportDto
    {
        [XmlElement("time")]
        public string Time { get; set; }

        [XmlElement("coords", typeof(CoordinateDto))]
        public CoordinateDto Coordinate { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("varX-Rating")]
        public string Rating { get; set; }
    }
}