using Magazin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Magazin.ViewModels
{
    public class OffersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Offer> OffersList { get; set; }

        string url = "http://partner.market.yandex.ru/pages/help/YML.xml";

        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get; set; }

        public OffersListViewModel()
        {
            OffersList = new ObservableCollection<Offer>();
            GetOffers();
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void GetOffers()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            System.Text.Encoding WINDOWS1251 = Encoding.GetEncoding(1251);

            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlElement root = doc.DocumentElement;
            var shop = root.FirstChild;

            XmlNode offers = shop.SelectSingleNode("offers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Offer));
            foreach (XmlNode childNode in offers.ChildNodes)
            {
                using (XmlNodeReader reader = new XmlNodeReader(childNode))
                {
                    Offer offer = (Offer)xmlSerializer.Deserialize(reader);
                    OffersList.Add(offer);
                }
            }
        }
    }
}
