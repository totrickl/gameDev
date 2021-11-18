using System.ComponentModel;
using System.Runtime.CompilerServices;
using CashFlow.Annotations;
using SQLite;

namespace CashFlow.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        //TODO: extend model with other fields
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        private string _playerName = string.Empty;
        private int _salary;
        private int _passiveIncome;
        private int _generalIncome;
        private int _generalExpense;
        private int _payCheck;
        private int _cash;
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

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string playerName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(playerName));
        }
    }
}