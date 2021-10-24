using System;
using System.Collections.Generic;
using WellBeing.Mobile.ViewModels;
using WellBeing.Mobile.Views;
using Xamarin.Forms;

namespace WellBeing.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
