using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using SQLite;
using Xamarin.Forms;

namespace CashFlow.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        public ICommand OnPlayerClickCommand => new Command(OnPlayerClick);

        public event PropertyChangedEventHandler PropertyChanged;

        private async void OnPlayerClick(object s)
        {
            Console.WriteLine("fdsfdsfds");
        }

        void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region private fields

        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        private string _playerName = string.Empty;
        private int _salary;
        private int _passiveIncome;
        private int _generalIncome;
        private int _generalExpense;
        private int _payCheck;
        private int _cash;
        private ICollection<BusinessViewModel> _businesses;
        private ICollection<StockViewModel> _stocks;
        private ICollection<RealEstateViewModel> _realEstates;

        #endregion

        //TODO: extend model with other fields

        #region get/set

        public string PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        public int Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }

        public int PassiveIncome
        {
            get => _passiveIncome;
            set
            {
                _passiveIncome = value;
                OnPropertyChanged(nameof(PassiveIncome));
            }
        }

        public int GeneralIncome
        {
            get => _generalIncome;
            set
            {
                _generalIncome = value;
                OnPropertyChanged(nameof(GeneralIncome));
            }
        }

        public int GeneralExpense
        {
            get => _generalExpense;
            set
            {
                _generalExpense = value;
                OnPropertyChanged(nameof(GeneralExpense));
            }
        }

        public int PayCheck
        {
            get => _payCheck;
            set
            {
                _payCheck = value;
                OnPropertyChanged(nameof(PayCheck));
            }
        }

        public int Cash
        {
            get => _cash;
            set
            {
                _cash = value;
                OnPropertyChanged(nameof(Cash));
            }
        }

        [Ignore]
        public ICollection<BusinessViewModel> Businesses
        {
            get => _businesses;
            set
            {
                _businesses = value ?? Enumerable.Empty<BusinessViewModel>().ToList();
                OnPropertyChanged(nameof(Businesses));
            }
        }

        [Ignore]
        public ICollection<StockViewModel> Stocks
        {
            get => _stocks;
            set
            {
                _stocks = value ?? Enumerable.Empty<StockViewModel>().ToList();
                OnPropertyChanged(nameof(Businesses));
            }
        }

        [Ignore]
        public ICollection<RealEstateViewModel> RealEstates
        {
            get => _realEstates;
            set
            {
                _realEstates = value ?? Enumerable.Empty<RealEstateViewModel>().ToList();
                OnPropertyChanged(nameof(Businesses));
            }
        }

        #endregion
    }
}