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
        OffersListViewModel lvm;

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

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
