using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Deposit : BankAccount
    {
        private const decimal MinBalance = 1000;

        public Deposit(Customer owner, decimal balance, decimal interestRate) :
            base(owner, balance, interestRate)
        {

        }

        public override decimal CalculateAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Number of months mast be positive.");
            }

            if (this.Balance < MinBalance)
            {
                return 0;
            }
            else
            {
                return (this.Balance * months * this.InterestRate) / 100;
            }
        }
    }
}
