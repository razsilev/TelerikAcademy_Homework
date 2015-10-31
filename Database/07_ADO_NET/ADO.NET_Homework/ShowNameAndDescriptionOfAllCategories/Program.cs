namespace ShowNameAndDescriptionOfAllCategories
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            string connectionString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=SSPI;";

            var dbCon = new SqlConnection(connectionString);

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", dbCon);

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Category name:           Description:");
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];

                        Console.WriteLine("{0, -15} : {1}", categoryName, description);
                    }
                }
            }
        }
    }
}
