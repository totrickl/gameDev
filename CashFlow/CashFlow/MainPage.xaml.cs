using System.Threading.Tasks;
using CashFlow.ViewModels;
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
            CreatePlayerPage page = null;
            
            await Task.Run(() =>
            {
                page = new CreatePlayerPage(new PlayerViewModel()
                {
                    PlayerName = "temp",
                    Salary = 1000,
                    Cash = 2000
                });
            });
            await Navigation.PushAsync(page);
        }
    }
}