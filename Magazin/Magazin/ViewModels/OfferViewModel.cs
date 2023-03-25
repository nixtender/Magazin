using Magazin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Magazin.ViewModels
{
    public class OfferViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Offer offer { get; set; }

        public OfferViewModel()
        {
            offer = new Offer();
        }

        public string Id
        {
            get { return offer.Id; }
            set
            {
                if (offer.Id != value)
                {
                    offer.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Url
        {
            get { return offer.Url; }
            set
            {
                if (offer.Url != value)
                {
                    offer.Url = value;
                    OnPropertyChanged("Url");
                }
            }
        }

        public string Price
        {
            get { return offer.Price; }
            set
            {
                if (offer.Price != value)
                {
                    offer.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
