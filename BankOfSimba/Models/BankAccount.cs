using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfSimba.Models
{
    public class BankAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Species { get; set; }
        public bool IsKing { get; set; }
        public bool IsGoodGuy { get; set; }
        public BankAccount(string name, decimal balance, string species, bool isGoodGuy, bool isKing)
        {
            Name = name;
            Balance = balance;
            Species = species;
            IsKing = isKing;
            IsGoodGuy = isGoodGuy;
        }
        public void IncreaseBalance()
        {
            Balance += IsKing ? 100 : 10;
        }
        public void ToggleKing()
        {
            IsKing = !IsKing;
        }
        public BankAccount() { }
    }
}
