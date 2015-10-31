namespace NortwindEditor
{
    using System;

    public class TestDAO
    {
        static void Main()
        {
            var customers = DAO.FindCustumersCanada1997();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ContactName);
            }

            customers = DAO.FindCustumersCanada1997WithNativeSql();

            Console.WriteLine("\n Same with native sql:");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ContactName);
            }

            Console.WriteLine("\nCreate NorthwindTwin, if exists delete it and created.");
            DAO.GenerateDatabaseFromModel();

            /*
             * 8. Try to open two different data contexts and perform concurrent
             *    changes on the same records. What will happen at SaveChanges()?
             *    How to deal with it?
             *    - Depends on isolation level. 
             */



        }
    }
}
