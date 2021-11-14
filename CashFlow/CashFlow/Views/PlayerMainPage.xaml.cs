using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CashFlow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerMainPage : ContentPage
    {
        public PlayerMainPage()
        {
            InitializeComponent();
        }

        public PlayerMainPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }
        
        private void OnEditModelButtonClicked(object sender, EventArgs e)
        {
            var layout = ((Button) sender).Parent.Parent;

            Grid buttonsGrid = layout.FindByName<Grid>("buttons");
            Grid fieldsGrid = layout.FindByName<Grid>("fields");
            
            fieldsGrid.Children.ForEach(f => f.IsEnabled = true);
            buttonsGrid.FindByName<Button>("saveChanges").IsVisible = true;
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            await App.database.SavePlayerAsync(BindingContext as PlayerViewModel);
            ((Button) sender).Parent.Parent.FindByName<Grid>("fields").Children.ForEach(f => f.IsEnabled = false);
            ((Button) sender).IsVisible = false;
        }
    }
}