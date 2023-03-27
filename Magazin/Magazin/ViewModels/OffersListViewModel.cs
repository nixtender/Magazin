using Magazin.Models;
using Magazin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Magazin.ViewModels
{
    public class OffersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<OfferViewModel> OffersList { get; set; }
        //public ICommand SelectOfferCommand { protected set; get; }
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

       /* private void SelectOffer()
        {
            Navigation.PushAsync(new OfferPage(new OfferViewModel() { ListViewModel = this })); 
        }*/

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
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
                    OfferViewModel offerVM = new OfferViewModel { Id = offer.Id, Url = offer.Url, Price = offer.Price };
                    OffersList.Add(offerVM);
                }
            }
        }
    }
}
