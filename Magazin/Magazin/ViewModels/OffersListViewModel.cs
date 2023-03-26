using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Xml;
using Xamarin.Forms;

namespace Magazin.ViewModels
{
    public class OffersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<OfferViewModel> Offers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public INavigation Navigation { get; set; }

        public OffersListViewModel()
        {
            Offers = new ObservableCollection<OfferViewModel>();
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void GetOffers()
        {
            string url = "http://partner.market.yandex.ru/pages/help/YML.xml";

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read())
            {
                // Do some work here on the data.
                Console.WriteLine(reader.Name);
            }
        }
    }
}
