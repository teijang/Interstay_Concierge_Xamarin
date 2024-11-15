﻿using Interstay_Concierge_Xamarin.ViewModels;
using Interstay_Concierge_Xamarin.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Interstay_Concierge_Xamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
