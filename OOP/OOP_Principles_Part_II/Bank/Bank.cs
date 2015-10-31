using System;
using System.Collections.Generic;

namespace Bank
{
    public class Bank
    {
        static void Main()
        {
            List<BankAccount> accounts = new List<BankAccount>();

            accounts.Add(new Deposit(new Company("Era"), 1234.43m, 3.4m));
            accounts.Add(new Deposit(new Company("Izot"), 995.43m, 2.5m));
            accounts.Add(new Deposit(new Individual("Pesho"), 3034.13m, 1.4m));
            accounts.Add(new Deposit(new Individual("Gosho"), 800m, 2.7m));
            accounts.Add(new Loan(new Individual("Emo"), 5000m, 1.3m));
            accounts.Add(new Loan(new Company("Era"), 8000m, 5.3m));
            accounts.Add(new Loan(new Company("Niki OOD"), 500m, 1m));
            accounts.Add(new Mortgage(new Company("Niki OOD"), 500m, 1m));
            accounts.Add(new Mortgage(new Individual("Mima"), 1110m, 1m));

            // to see diferent result change months
            int months = 7;

            foreach (var account in accounts)
            {
                Console.WriteLine("Type account: {2} = {5:C} \nowner {0} ({3})\n{4} month amount = {1:C}\n",
                            account.Owner.GetName, account.CalculateAmount(months),
                            account.GetType().Name, account.Owner.GetType().Name, months, account.Balance);
            }            
        }
    }
}
