using System;
using SQLite;

namespace CashFlow.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }

        public string PlayerName { get; set; }
        public int Salary { get; set; }
        public int PassiveIncome { get; set; }
        public int GeneralIncome { get; set; }
        public int GeneralExpense { get; set; }
        public int PayCheck { get; set; }

        public Business[] Businesses { get; set; } = Array.Empty<Business>();
        public Stock[] Stocks { get; set; } = Array.Empty<Stock>();
        public RealEstate[] RealEstates { get; set; } = Array.Empty<RealEstate>();
    }
}