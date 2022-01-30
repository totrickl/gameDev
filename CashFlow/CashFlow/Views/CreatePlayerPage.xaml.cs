using System;
using Xamarin.Forms;
using CashFlow.ViewModels;

namespace CashFlow.Views
{
    public partial class CreatePlayerPage : ContentPage
    {
        private PlayerViewModel _player = null;

        public CreatePlayerPage()
        {
            InitializeComponent();
            PlayerViewModel newPlayer = new()
            {
                Id = App.database.TotalPlayersCount + 1,
                PlayerName = "temp",
                Salary = 1000,
                Cash = 2000
            };
            BindingContext = _player ?? newPlayer;
        }

        private async void PreparePlayer()
        {
            _player = await App.database.GetLastAddedPlayer();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is PlayerViewModel player)
            {
                // var playerCreated = await App.database.SavePlayerAsync(player);
                // var playerCreated = await App.database.GetPlayerById(player.Id);
                await Navigation.PushAsync(new PlayerMainPage(player));
            }
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Navigate backwards
            await Navigation.PopAsync();
        }
    }
}