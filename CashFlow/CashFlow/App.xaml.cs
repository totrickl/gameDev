using System;
using System.IO;
using CashFlow.DataAccess;
using CashFlow.ViewModels;
using CashFlow.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CashFlow
{
    public partial class App : Application
    {
        private static DbAccessor _database;

        public App()
        {
            InitializeComponent();

            var mainPageViewModel = new MainPageViewModel()
            {
                Players = Database.GetPlayersAsync(3).GetAwaiter().GetResult()
            };


            MainPage = new NavigationPage(new MainPage(mainPageViewModel));
            // MainPage = new AppShell();
        }

        public static DbAccessor Database
        {
            get
            {
                return _database ??= new DbAccessor(Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CashflowAppDb.db3"));
            }
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