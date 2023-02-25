using System;
using Xamarin.Forms;
using CashFlow.ViewModels;

namespace CashFlow.Views
{
    public partial class ApplicationStartingPage : ContentPage
    {
        public ApplicationStartingPage()
        {
            InitializeComponent();
        }

        public ApplicationStartingPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is PlayerViewModel player)
            {
                var playerCreated = await App.Database.SavePlayerAsync(player);
                // var playerCreated = await App.database.GetPlayerById(player.Id);
                await Navigation.PushAsync(new PlayerMainPage(playerCreated));
            }
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Navigate backwards
            await Navigation.PopAsync();
        }
    }
}