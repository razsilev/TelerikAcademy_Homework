namespace ShowNumberOfRowsInCategoriesNortwind
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            string connectionString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=SSPI;";

            var dbCon = new SqlConnection(connectionString);
            int numberOfRows = 0;

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);

                numberOfRows = (int)command.ExecuteScalar();
            }

            Console.WriteLine("Number Of Rows in Categories is: {0}", numberOfRows);
        }
    }
}
