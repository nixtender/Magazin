using Magazin.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Xml;
using System.Net;
using System.Text;
using System;
using System.Xml.Serialization;
using System.IO;
using Magazin.Models;
using System.Xml.Linq;

namespace Magazin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersListPage : ContentPage
    {
        public OffersListPage()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
            BindingContext = new OffersListViewModel { Navigation = this.Navigation };

            System.Text.Encoding WINDOWS1251 = Encoding.GetEncoding(1251);
            /*System.Text.Encoding UTF8 = Encoding.UTF8;*/

            string url = "http://partner.market.yandex.ru/pages/help/YML.xml";


            /*HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            XmlSerializer serializer = new XmlSerializer(typeof(Offer));
            Offer offer = (Offer)serializer.Deserialize(responseStream);
            Console.WriteLine(offer.Id);*/

            string xmlDoc = "";

            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlElement root = doc.DocumentElement;
            var shop = root.FirstChild;
            /*XmlNode offers;
            foreach (XmlNode childNode in shop)
            {
                if (childNode.Name == "offers")
                    offers = childNode;
            }*/
            XmlNode offers = shop.SelectSingleNode("offers");
            foreach(XmlNode childNode in offers.ChildNodes)
            {
                Console.WriteLine(childNode.Attributes["id"].Value);
            }
            Console.WriteLine(offers.ToString());

            /*XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        xmlDoc += "<" + reader.Name;

                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            xmlDoc += " " + reader.Name + "='" + reader.Value + "'";
                        //xmlDoc += ">";
                        if (reader.)

                        xmlDoc += ">";
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        xmlDoc += reader.Value;
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        xmlDoc += "</" + reader.Name;
                        xmlDoc += ">";
                        break;
                }
            }
            Console.WriteLine(xmlDoc);
            XElement yml_catalog = XElement.Parse(xmlDoc);
            XElement shop = XElement.Parse(yml_catalog.ToString());
            XElement offers = XElement.Parse(shop.ToString());
            Console.WriteLine(offers.ToString());*/
        }
    }
}