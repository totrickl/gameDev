using System.Runtime.CompilerServices;
using SQLite;

namespace CashFlow.ViewModels
{
    public abstract class InvestmentBase
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public int PlayerId  { get; set; }
        public string Name { get; set; }
        public int FirstPayment { get; set; }
        public int Cost { get; set; }
    }
}