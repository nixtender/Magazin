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
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Magazin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersListPage : ContentPage
    {

        public OffersListPage()
        {
            InitializeComponent();
            BindingContext = new OffersListViewModel { Navigation = this.Navigation };


            /*HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            XmlSerializer serializer = new XmlSerializer(typeof(Offer));
            Offer offer = (Offer)serializer.Deserialize(responseStream);
            Console.WriteLine(offer.Id);*/
            //
            /*string xmlDoc = "";

            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlElement root = doc.DocumentElement;
            var shop = root.FirstChild;

            XmlNode offers = shop.SelectSingleNode("offers");
            foreach(XmlNode childNode in offers.ChildNodes)
            {
                Console.WriteLine(childNode.Attributes["id"].Value);
            }
            Console.WriteLine(offers.ToString());*/
            //
            /*
            Console.WriteLine(xmlDoc);
            XElement yml_catalog = XElement.Parse(xmlDoc);
            XElement shop = XElement.Parse(yml_catalog.ToString());
            XElement offers = XElement.Parse(shop.ToString());
            Console.WriteLine(offers.ToString());*/
        }


        protected override async void OnAppearing()
        {
            
            /*var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetStringAsync(url);
            var ser = new XmlSerializer(typeof(Offer));
            var t = (Offer)ser.Deserialize(new StringReader(httpResponse));
            //XElement shop = XElement.Parse(xmlString);
            Console.WriteLine(t.Id);*/
        }


    }
}