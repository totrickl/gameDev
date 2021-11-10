using System.Collections.Generic;

namespace CashFlow.Models
{
    public class SmallCircle : Player
    {
        public IEnumerable<Investment> Businesses { get; set; }
        public IEnumerable<Investment> RealEstates { get; set; }
        public IEnumerable<Stock> Stocks { get; set; }
    }
}