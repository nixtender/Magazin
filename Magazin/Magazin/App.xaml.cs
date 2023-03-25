using Magazin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Magazin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OffersListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
