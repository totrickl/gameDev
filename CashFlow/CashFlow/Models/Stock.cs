namespace CashFlow.Models
{
    //акції
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int SingleStockCost { get; set; }
        public int TotalSum { get; set; }
    }
}