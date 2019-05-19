namespace WebApi_NetFr_EntityFr_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi_NetFr_EntityFr_CodeFirst.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // to allow colums drop
            ContextKey = "WebApi_NetFr_EntityFr_CodeFirst.Models.SchoolContext";
        }

        protected override void Seed(WebApi_NetFr_EntityFr_CodeFirst.Models.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
