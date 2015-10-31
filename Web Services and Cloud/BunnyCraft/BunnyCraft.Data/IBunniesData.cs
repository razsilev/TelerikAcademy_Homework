namespace BunnyCraft.Data
{
    using BunnyCraft.Data.Repositories;
    using BunnyCraft.Models;

    public interface IBunniesData
    {
        IRepository<AirCraft> Aircrafts { get; }

        IRepository<Bunny> Bunnies { get; }

        void SaveChanges();
    }
}
