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
            //Content.BindingContext = App.database.GetPlayerById(-1);
        }
        public CreatePlayerPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }

        /*protected override async void OnAppearing()
        {
            base.OnAppearing();/*
            var player = await App.database.GetPlayerById(-1);
            BindingContext = player;
            this.ApplyBindings();#1#
        }*/
        
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