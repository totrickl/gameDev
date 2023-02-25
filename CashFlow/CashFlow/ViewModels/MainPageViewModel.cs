using System;

namespace CashFlow.ViewModels
{
    public class MainPageViewModel
    {
        public PlayerViewModel[] Players { get; set; } = Array.Empty<PlayerViewModel>();
    }
}