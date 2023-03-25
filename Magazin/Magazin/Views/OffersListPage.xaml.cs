using Magazin.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Magazin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersListPage : ContentPage
    {
        public OffersListPage()
        {
            InitializeComponent();
            BindingContext = new OffersListViewModel { Navigation = this.Navigation };
        }
    }
}