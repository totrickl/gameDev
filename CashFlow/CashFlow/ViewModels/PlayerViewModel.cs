using System.ComponentModel;
using System.Runtime.CompilerServices;
using CashFlow.Annotations;

namespace CashFlow.ViewModels
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        //TODO: extend model with other fields
        private string _playerName = string.Empty;
        private int _salary = 0;
        private int _passiveIncome = 0;
        private int _generalIncome = 0;
        private int _generalExpense = 0;
        private int _payCheck = 0;
        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }
        public int Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }
        
        public int PassiveIncome
        {
            get { return _passiveIncome; }
            set
            {
                _passiveIncome = value;
                OnPropertyChanged(nameof(PassiveIncome));
            }
        }
        
        public int GeneralIncome
        {
            get { return _generalIncome; }
            set
            {
                _generalIncome = value;
                OnPropertyChanged(nameof(GeneralIncome));
            }
        }
        
        public int GeneralExpense
        {
            get { return _generalExpense; }
            set
            {
                _generalExpense = value;
                OnPropertyChanged(nameof(GeneralExpense));
            }
        }
        
        public int PayCheck
        {
            get { return _payCheck; }
            set
            {
                _payCheck = value;
                OnPropertyChanged(nameof(PayCheck));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string playerName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(playerName));
        }
    }
}