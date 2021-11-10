using System.Collections.Generic;

namespace CashFlow.Models
{
    public class BigCircle : Player
    {
        public int PassiveIncomeFromSmallCircle { get; set; }
        public int InitialPassiveIncome { get; set; }
        public int WinningPassiveIncome { get; set; }
        public IEnumerable<Business> Businesses { get; set; }
    }
}