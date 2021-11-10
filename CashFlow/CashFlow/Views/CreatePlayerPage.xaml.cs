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
        private DataAccessor _accessor;
        public CreatePlayerPage()
        {
            _accessor = new DataAccessor();
            InitializeComponent();
        }
        public CreatePlayerPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var player = BindingContext as  Player;
            Console.WriteLine($"Player {player.PlayerName} created");
            var jsonData = JsonSerializer.Serialize(player);
            /*using (StreamReader sr = new StreamReader(jsonData))
            {
                _accessor.UpdateFileData(sr);
            }*/
            Console.WriteLine("Data {0}", jsonData);
            // Navigate backwards
            //await Shell.Current.GoToAsync("..");
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            // Navigate backwards
            await Navigation.PopAsync();
        }
    }
}