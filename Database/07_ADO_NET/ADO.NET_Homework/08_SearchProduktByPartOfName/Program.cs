namespace _08_SearchProduktByPartOfName
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Find All products from Northwind DB who contains searched string.\n");
            Console.Write("Enter part of product name: ");

            string str = Console.ReadLine();
            var foundProductsNames = FindProductBy(str);

            PrintResults(foundProductsNames);
        }

        private static void PrintResults(ICollection<string> foundProductsNames)
        {
            Console.WriteLine("\nFound products names:");

            foreach (var name in foundProductsNames)
            {
                Console.WriteLine(name);
            }
        }

        private static ICollection<string> FindProductBy(string partOfName)
        {
            var names = new List<string>();
            string connectionString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=SSPI;";

            var dbCon = new SqlConnection(connectionString);

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT p.ProductName FROM Products p WHERE p.ProductName LIKE @Search", dbCon);

                command.Parameters.AddWithValue("@Search", "%" + partOfName + "%");

                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("\nProductNams that contains ({0}):\n", partOfName);
                using (reader)
                {
                    string categoryName = string.Empty;
                    string currentCategoryName = string.Empty;
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];

                        names.Add(productName);
                    }
                }
            }

            return names;
        }
    }
}
