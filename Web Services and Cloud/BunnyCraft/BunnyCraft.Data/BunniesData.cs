namespace BunnyCraft.Data
{
    using System;
    using System.Collections.Generic;

    using BunnyCraft.Data.Repositories;
    using BunnyCraft.Models;

    public class BunniesData : IBunniesData
    {
        private IBunnyDbContext context;
        private IDictionary<Type, object> repositories;

        public BunniesData()
            : this(new BunnyDbContext())
        {
        }

        public BunniesData(IBunnyDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Bunny> Bunnies
        {
            get
            {
                return this.GetRepository<Bunny>();
            }
        }

        public IRepository<AirCraft> Aircrafts
        {
            get
            {
                return this.GetRepository<AirCraft>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
