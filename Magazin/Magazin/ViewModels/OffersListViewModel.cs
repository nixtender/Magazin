using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
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

        private async string GetOffers()
        {

        }
    }
}
