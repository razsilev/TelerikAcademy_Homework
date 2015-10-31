using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public abstract class BankAccount
    {
        public Customer Owner { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }

        public BankAccount(Customer owner, decimal balance, decimal interestRate)
        {
            this.Owner = owner;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public abstract decimal CalculateAmount(int months);
    }
}
