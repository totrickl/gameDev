using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.Json;
using CashFlow.DataAccess;

namespace CashFlow.Views
{
    public partial class CreatePlayerPage : ContentPage
    {
        public CreatePlayerPage()
        {
            InitializeComponent();
            Content.BindingContext = App.database.GetPlayerById(-1);
        }
        public CreatePlayerPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Content.BindingContext = await App.database.GetPlayerById(0);
        }
        
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var player = BindingContext as  Player;
            if (player != null)
            {
                await App.database.SavePlayerAsync(player);
            }
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Navigate backwards
            await Navigation.PopAsync();
        }
    }
}