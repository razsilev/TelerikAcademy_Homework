using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Loan : BankAccount
    {
        private const int CompanyMinMonths = 2;
        private const int IndividualMinMonths = 3;

        public Loan(Customer owner, decimal balance, decimal interestRate) :
            base(owner, balance, interestRate)
        {

        }

        public override decimal CalculateAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Number of months mast be positive.");
            }

            if (this.Owner is Company)
            {
                if (months > CompanyMinMonths)
                {
                    months -= CompanyMinMonths;

                    return (this.Balance * months * this.InterestRate) / 100;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (months > IndividualMinMonths)
                {
                    months -= IndividualMinMonths;

                    return (this.Balance * months * this.InterestRate) / 100;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
