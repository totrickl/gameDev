using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CashFlow.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsLibrary1;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CashFlow
{
    public partial class App : Application
    {
        //public static string FolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            // DependencyService.Register<IFileHelper>();
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new MainPage());
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