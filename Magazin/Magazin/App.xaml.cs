using Magazin.Views;
using System;
using Xamarin.Forms;
using System.Xml;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using Magazin.Models;
using System.Text;
using System.Data.SqlTypes;
using System.Net.Mime;

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
