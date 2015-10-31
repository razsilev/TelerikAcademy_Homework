namespace AddProductInProductsNorthwind
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            int insertedRows = 0;
            insertedRows = AddProduct("tomato", 3, 2, 500, 1.5m, 12, 3, 2, 6);
            Console.WriteLine("Inserted rows: {0}", insertedRows);

            insertedRows = AddProduct("cerats", 3, 5, 500, 1.5m, 12, 3, 2, 6);
            Console.WriteLine("Inserted rows: {0}", insertedRows);
        }

        public static int AddProduct(string name, int? supplierID, int? categoryID, int? quantity, decimal? price, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, byte discontinued)
        {
            string connectionString = "Data Source=.;Initial Catalog=Northwind;Integrated Security=SSPI;";
            var dbCon = new SqlConnection(connectionString);
            int numbersOfRowsAfected = 0;

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                 "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                 "VALUES (@name, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbCon);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@supplierID", supplierID);
                command.Parameters.AddWithValue("@categoryID", categoryID);
                command.Parameters.AddWithValue("@quantityPerUnit", quantity);
                command.Parameters.AddWithValue("@unitPrice", price);
                command.Parameters.AddWithValue("@unitsInStock", unitsInStock);
                command.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
                command.Parameters.AddWithValue("@reorderLevel", reorderLevel);
                command.Parameters.AddWithValue("@discontinued", discontinued);

                numbersOfRowsAfected = command.ExecuteNonQuery();
            }

            return numbersOfRowsAfected;
        }
    }
}