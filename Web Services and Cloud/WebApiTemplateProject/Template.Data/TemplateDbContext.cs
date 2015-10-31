namespace Template.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Template.Models;
    using Template.Data.Migrations;

    public class TemplateDbContext : IdentityDbContext<User>
    {
        public TemplateDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TemplateDbContext, Configuration>());
        }

        public static TemplateDbContext Create()
        {
            return new TemplateDbContext();
        }

        // Add IDbSet<from other Entiies in the database for user olredy have>()
    }
}
