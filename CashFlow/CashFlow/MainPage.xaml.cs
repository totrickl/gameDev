using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using CashFlow.DataAccess;
using CashFlow.Models;
using CashFlow.Views;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamarinFormsLibrary1;

namespace CashFlow
{
    public partial class MainPage : ContentPage
    {
        private DataAccessor _accessor;
        public MainPage()
        {
            _accessor = new DataAccessor();
            InitializeComponent();
        }
        
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CreatePlayerPage(_accessor.Player));
        }
    }
}