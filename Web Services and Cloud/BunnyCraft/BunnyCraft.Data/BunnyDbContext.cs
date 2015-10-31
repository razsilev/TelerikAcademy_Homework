namespace BunnyCraft.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BunnyCraft.Models;
    using BunnyCraft.Data.Migrations;

    public class BunnyDbContext : DbContext, IBunnyDbContext
    {
        public BunnyDbContext()
            : base("BunnyCraftConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BunnyDbContext, Configuration>());
        }

        public virtual IDbSet<Bunny> Bunnies { get; set; }

        public virtual IDbSet<AirCraft> AirCrafts { get; set; }


        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
