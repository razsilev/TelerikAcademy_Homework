namespace ShowProductsInCategories
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
                    "SELECT c.CategoryName, p.ProductName FROM Products p INNER JOIN Categories c ON p.CategoryID = c.CategoryID ORDER BY c.CategoryName ASC", dbCon);

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Category name:           ProductName:");
                using (reader)
                {
                    string categoryName = string.Empty;
                    string currentCategoryName = string.Empty;
                    while (reader.Read())
                    {
                        string newCategoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        if (newCategoryName != currentCategoryName)
                        {
                            Console.WriteLine();
                            categoryName = newCategoryName;
                            currentCategoryName = newCategoryName;
                        }
                        else
                        {
                            categoryName = string.Empty;
                        }

                        Console.WriteLine("{0, -15} : {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}
