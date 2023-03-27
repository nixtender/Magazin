using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Magazin.Models
{
    [XmlRoot(ElementName = "offer")]
    public class Offer
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }

        public string JsonParam { get; set; }
    }
}
