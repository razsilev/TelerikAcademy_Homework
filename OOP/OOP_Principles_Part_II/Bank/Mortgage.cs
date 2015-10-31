using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Mortgage : BankAccount
    {
        private const int IndividualMonthsWthoutInterest = 6;
        private const int CompanyPromotionInterestMonths = 12;

        public Mortgage(Customer owner, decimal balance, decimal interestRate) :
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
                if (months > CompanyPromotionInterestMonths)
                {
                    months -= CompanyPromotionInterestMonths;

                    // amount for 12 months
                    decimal interest = this.InterestRate / 2;
                    decimal amount = (this.Balance * CompanyPromotionInterestMonths * interest) / 100;

                    months -= CompanyPromotionInterestMonths;

                    return amount + ((this.Balance * months * this.InterestRate) / 100);
                }
                else
                {
                    // months <= 12
                    decimal interest = this.InterestRate / 2;
                    return (this.Balance * months * interest) / 100;
                }
            }
            else
            {
                if (months > IndividualMonthsWthoutInterest)
                {
                    months -= IndividualMonthsWthoutInterest;

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
