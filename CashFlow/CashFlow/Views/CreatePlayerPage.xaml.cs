using System;
using Xamarin.Forms;
using CashFlow.ViewModels;

namespace CashFlow.Views
{
    public partial class CreatePlayerPage : ContentPage
    {
        public CreatePlayerPage()
        {
            InitializeComponent();
        }
        public CreatePlayerPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is PlayerViewModel player)
            {
                await App.database.SavePlayerAsync(player);
                var playerCreated = await App.database.GetPlayerById(player.Id);
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