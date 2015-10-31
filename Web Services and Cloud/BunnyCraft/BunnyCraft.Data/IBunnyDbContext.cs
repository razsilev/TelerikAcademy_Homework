namespace BunnyCraft.Data
{
    using BunnyCraft.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public interface IBunnyDbContext
    {
        IDbSet<Bunny> Bunnies { get; set; }

        IDbSet<AirCraft> AirCrafts { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
