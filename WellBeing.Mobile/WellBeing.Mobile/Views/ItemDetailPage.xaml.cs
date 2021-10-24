using System.ComponentModel;
using WellBeing.Mobile.ViewModels;
using Xamarin.Forms;

namespace WellBeing.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}