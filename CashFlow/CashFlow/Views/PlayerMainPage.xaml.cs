using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
            if (((Button)sender).Parent is Grid grid)
            {
                foreach (var child in grid.Children)
                {
                    child.IsEnabled = true;
                }
            }
        }
    }
}