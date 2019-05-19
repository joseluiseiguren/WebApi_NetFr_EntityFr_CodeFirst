using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi_NetFr_EntityFr_CodeFirst.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=SchoolDBConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public DbSet<Province> Provinces { get; set; }
    }
}