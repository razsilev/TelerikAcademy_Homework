namespace NortwindEditor
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;

    public static class DAO
    {
        public static void AddCustumer(Customer custumer)
        {
            using (var db = new NorthwindEntities())
            {
                db.Customers.Add(custumer);

                db.SaveChanges();
            }
        }

        public static bool UpdateCustumer(int custumerID, Customer updatedCustomer)
        {
            bool isUpdated = false;

            using (var db = new NorthwindEntities())
            {
                var custumer = db.Customers.Find(custumerID);

                if (custumer != null)
                {
                    custumer.Address = updatedCustomer.Address;
                    custumer.City = updatedCustomer.City;
                    custumer.CompanyName = updatedCustomer.CompanyName;
                    custumer.ContactName = updatedCustomer.ContactName;
                    custumer.ContactTitle = updatedCustomer.ContactTitle;
                    custumer.Country = updatedCustomer.Country;
                    custumer.CustomerDemographics = updatedCustomer.CustomerDemographics;
                    custumer.Fax = updatedCustomer.Fax;
                    custumer.Orders = updatedCustomer.Orders;
                    custumer.Phone = updatedCustomer.Phone;
                    custumer.PostalCode = updatedCustomer.PostalCode;
                    custumer.Region = updatedCustomer.Region;

                    isUpdated = true;
                }

                db.SaveChanges();
            }

            return isUpdated;
        }

        public static bool DeleteCustumer(int custumerID)
        {
            bool isDeleted = false;

            using (var db = new NorthwindEntities())
            {
                var custumer = db.Customers.Find(custumerID);

                if (custumer != null)
                {
                    db.Customers.Remove(custumer);

                    isDeleted = true;
                }

                db.SaveChanges();
            }

            return isDeleted;
        }

        public static ICollection<Customer> FindCustumersCanada1997()
        {
            ICollection<Customer> custumers;

            using (var db = new NorthwindEntities())
            {
                custumers = db.Orders
                            .Where(o => o.ShipCountry == "Canada" && o.OrderDate.Value.Year == 1997)
                            .Select(o => o.Customer).ToList();
            }

            return custumers;
        }

        public static ICollection<Customer> FindCustumersCanada1997WithNativeSql()
        {
            ICollection<Customer> custumers;

            using (var db = new NorthwindEntities())
            {
                custumers = db.Customers.SqlQuery("SELECT * FROM Customers c INNER JOIN Orders o ON o.CustomerID = c.CustomerID "
                    + "WHERE o.ShipCountry = 'Canada' AND YEAR(o.OrderDate) = 1997").ToList();
            }

            return custumers;
        }

        public static ICollection<Order> GetSalesByRegionAndYear(string shipRegion, DateTime? beginningDate, DateTime? endingDate)
        {
            ICollection<Order> custumers;

            using (var db = new NorthwindEntities())
            {
                custumers = db.Orders
                            .Where(o => o.ShipRegion == shipRegion &&
                                o.OrderDate >= beginningDate &&
                                o.OrderDate <= endingDate)
                            .ToList();
            }

            return custumers;
        }

        public static void GenerateDatabaseFromModel()
        {
            var db = new NorthwindEntities();
            string createDatabaseScript = (db as IObjectContextAdapter).ObjectContext.CreateDatabaseScript();
            SqlConnection connection = new SqlConnection("Server=.;Trusted_Connection=True;");
            connection.Open();
            
            using (connection)
            {
                // delete if exists
                SqlCommand deleteDatabaseNorthwindTwin = new SqlCommand("USE master; IF EXISTS(SELECT * FROM sys.databases where name='NorthwindTwin') DROP DATABASE NorthwindTwin", connection);
                deleteDatabaseNorthwindTwin.ExecuteNonQuery();

                SqlCommand useMasterCommand = new SqlCommand("USE master", connection);
                useMasterCommand.ExecuteNonQuery();
                SqlCommand createDatabaseCommand = new SqlCommand(
                "CREATE DATABASE NorthwindTwin",
                connection);
                createDatabaseCommand.ExecuteNonQuery();
                SqlCommand useNewDatabaseCommand = new SqlCommand("USE NorthwindTwin", connection);
                useNewDatabaseCommand.ExecuteNonQuery();
                SqlCommand copySchemaCommand = new SqlCommand(createDatabaseScript, connection);
                copySchemaCommand.ExecuteNonQuery();
            }
        }
    }
}
