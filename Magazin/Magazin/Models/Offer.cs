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
        /*public string CurrencyId { get; set; }
        public string CategoryId { get; set; }
        public string Picture { get; set; }
        public string Delivery { get; set; }
        public string LocalDeliveryCost { get; set; }
        public string TypePrefix { get; set; }
        public string Vendor { get; set; }
        public string VendorCode { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string ManufacturerWarranty { get; set; }
        public string CountryOfOrigin { get; set; }*/
    }
}
