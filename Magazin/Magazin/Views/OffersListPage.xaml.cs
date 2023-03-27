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
        OffersListViewModel vm;

        public OffersListPage()
        {
            InitializeComponent();
            vm = new OffersListViewModel { Navigation = this.Navigation };
            BindingContext = vm;


            
        }

        /*private async void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Offer offer = (Offer)e.SelectedItem;
            await Navigation.PushAsync(new OfferPage(new OfferViewModel() { ListViewModel = vm }));
        }*/

    }
}