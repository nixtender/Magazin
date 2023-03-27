using Magazin.Models;
using Magazin.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Magazin.ViewModels
{
    public class OffersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<OfferViewModel> OffersList { get; set; }
        OfferViewModel selectedOffer;
        readonly string url = "http://partner.market.yandex.ru/pages/help/YML.xml";

        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get; set; }

        public OffersListViewModel()
        {
            OffersList = new ObservableCollection<OfferViewModel>();
            GetOffers();
        }

        public OfferViewModel SelectedOffer
        {
            get { return selectedOffer; }
            set
            {
                if (selectedOffer != value)
                {
                    OfferViewModel tempOffer = value;
                    selectedOffer = null;
                    OnPropertyChanged("SelectedOffer");
                    Navigation.PushAsync(new OfferPage(tempOffer));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public async void GetOffers()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            System.Text.Encoding WINDOWS1251 = Encoding.GetEncoding(1251);

            HttpClient httpClient = new HttpClient();
            var data = await httpClient.GetAsync(url);
            var buffer = await data.Content.ReadAsByteArrayAsync();
            byte[] bytes = buffer.ToArray();
            string dataString = WINDOWS1251.GetString(bytes, 0, bytes.Length);
            dataString = dataString.Replace("<!DOCTYPE yml_catalog SYSTEM \"shops.dtd\">", "");

            var doc = new XDocument();
            doc = XDocument.Parse(dataString);
            XElement root = doc.Element("yml_catalog");
            var shop = root.Element("shop");
            var offers = shop.Element("offers");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Offer));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(offers.ToString());
            XmlNode xmlOff = xmlDoc.FirstChild;
            foreach (XmlNode childNode in xmlOff.ChildNodes)
            {
                using (XmlNodeReader reader = new XmlNodeReader(childNode))
                {
                    Offer offer = (Offer)xmlSerializer.Deserialize(reader);
                    offer.JsonParam = JsonHelper.FormatJson(JsonConvert.SerializeXmlNode(childNode));
                    OfferViewModel offerVM = new OfferViewModel { Id = offer.Id, Url = offer.Url, Price = offer.Price, JsonParam = offer.JsonParam };
                    OffersList.Add(offerVM);
                }
            }
        }
    }
}
