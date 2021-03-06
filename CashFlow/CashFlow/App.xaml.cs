using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CashFlow.DataAccess;
using CashFlow.ViewModels;
using CashFlow.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CashFlow
{
    public partial class App : Application
    {
        private static DbAccessor _database;
        public static DbAccessor database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DbAccessor(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "player.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            // MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}