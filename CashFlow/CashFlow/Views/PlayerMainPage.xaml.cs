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

            Grid buttonsGrid = layout.FindByName<Grid>("Buttons");
            Grid fieldsGrid = layout.FindByName<Grid>("Fields");

            SwitchEntriesEnabled(fieldsGrid.Children, true);
            buttonsGrid.FindByName<Button>("SaveChanges").IsVisible = true;
        }

        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            await App.database.SavePlayerAsync(BindingContext as PlayerViewModel);
            SwitchEntriesEnabled(((Button) sender).Parent.Parent.FindByName<Grid>("Fields").Children, false);
            ((Button) sender).IsVisible = false;
        }

        private void SwitchEntriesEnabled(IList<View> fields, bool enabled)
        {
            fields.OfType<Entry>().ForEach(f => f.IsEnabled = enabled);
        }
    }
}