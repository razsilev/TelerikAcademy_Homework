namespace CarStore.Data
{
    using CarStore.Data.Migrations;
    using CarStore.Models;
    using System.Data.Entity;

    public class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext()
            : base("CarStoreConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarStoreDbContext, Configuration>());
        }

        public IDbSet<City> Citys { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }


    }
}
