using System.Collections;

namespace CashFlow.Models
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int Salary { get; set; }
        public int PassiveIncome { get; set; }
        public int GeneralIncome { get; set; }
        public int GeneralExpense { get; set; }
        public int PayCheck { get; set; }
    }
}