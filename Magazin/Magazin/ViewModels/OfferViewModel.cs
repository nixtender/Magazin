using Magazin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static Xamarin.Essentials.Permissions;
using Xamarin.Essentials;

namespace Magazin.ViewModels
{
    public class OfferViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        OffersListViewModel lvm;
        string json = "";

        public Offer Offer { get; set; }

        public OfferViewModel()
        {
            Offer = new Offer();
        }

        public OffersListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Json
        {
            get
            {
                string j = JsonConvert.SerializeObject(Offer, Formatting.Indented);
                return j;
            }
            set
            {
                if (json != value)
                {
                    json = value;
                    OnPropertyChanged("Json");
                }
            }
        }

        public string Id
        {
            get { return Offer.Id; }
            set
            {
                if (Offer.Id != value)
                {
                    Offer.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Url
        {
            get { return Offer.Url; }
            set
            {
                if (Offer.Url != value)
                {
                    Offer.Url = value;
                    OnPropertyChanged("Url");
                }
            }
        }

        public string Price
        {
            get { return Offer.Price; }
            set
            {
                if (Offer.Price != value)
                {
                    Offer.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public string JsonParam
        {
            get { return Offer.JsonParam; }
            set
            {
                if (Offer.JsonParam != value)
                {
                    Offer.JsonParam = value;
                    OnPropertyChanged("JsonParam");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
