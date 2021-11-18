namespace CashFlow.Models
{
    public abstract class Investment
    {
        public string Name { get; set; }
        public int FirstPayment { get; set; }
        public int Cost { get; set; }
    }
}