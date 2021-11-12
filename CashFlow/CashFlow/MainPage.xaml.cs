using CashFlow.Views;
using Xamarin.Forms;

namespace CashFlow
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CreatePlayerPage());
        }
    }
}