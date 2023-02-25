using System.Threading.Tasks;
using CashFlow.ViewModels;
using Xamarin.Forms;

namespace CashFlow.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(object bindingContext)
        {
            InitializeComponent();
            BindingContext = bindingContext;
        }

        async void OnCreatePlayerClicked(object sender, System.EventArgs e)
        {
            ApplicationStartingPage page = null;
            await Task.Run(() =>
            {
                page = new ApplicationStartingPage(new PlayerViewModel()
                {
                    PlayerName = "temp",
                    Salary = 1000,
                    Cash = 2000
                });
            });
            await Navigation.PushAsync(page);
        }

        async void OnGoToPlayerPageButtonClicked(object sender, System.EventArgs e)
        {
            var viewCell = sender as ViewCell;

            if (viewCell?.BindingContext is PlayerViewModel bc)
            {
                await Navigation.PushAsync(new PlayerMainPage(bc));
            }
        }
    }
}