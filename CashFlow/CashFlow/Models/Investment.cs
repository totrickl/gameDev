using SQLite;

namespace CashFlow.Models
{
    public abstract class Investment
    {
        [PrimaryKey] public int PlayerId { get; set; }

        public string Name { get; set; }
        public int FirstPayment { get; set; }
        public int Cost { get; set; }
    }
}