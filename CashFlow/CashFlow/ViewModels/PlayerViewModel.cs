using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CashFlow.Annotations;
using CashFlow.Models;
using SQLite;

namespace CashFlow.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        #region private fields
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        private string _playerName = string.Empty;
        private int _salary;
        private int _passiveIncome;
        private int _generalIncome;
        private int _generalExpense;
        private int _payCheck;
        private int _cash;
        private ICollection<Investment> _businesses;
        private ICollection<Investment> _stocks;
        private ICollection<Investment> _realEstates;
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
            get =>  _salary;
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
        public ICollection<Investment> Businesses
        {
            get => _businesses;
            set
            {
                _businesses = value;
                OnPropertyChanged(nameof(Businesses));
            }
        }
        public ICollection<Investment> Stocks
        {
            get => _stocks;
            set
            {
                _stocks = value;
                OnPropertyChanged(nameof(Stocks));
            }
        }
        public ICollection<Investment> RealEstates
        {
            get => _realEstates;
            set
            {
                _realEstates = value;
                OnPropertyChanged(nameof(RealEstates));
            }
        }

        #endregion
        
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}