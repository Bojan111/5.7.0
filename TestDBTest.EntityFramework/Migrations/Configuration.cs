using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using TestDBTest.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using TestDBTest.Entities;

namespace TestDBTest.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<TestDBTest.EntityFramework.TestDBTestDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
      
        }

        protected override void Seed(TestDBTest.EntityFramework.TestDBTestDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();


            context.People.AddOrUpdate(
            p => p.Name,
            new Person { Name = "Isaac", LastName = "Asimov", AssignedCountryId = 1 },
            new Person { Name = "Thomas", LastName = "More", AssignedCountryId = 2 },
            new Person { Name = "George", LastName = "Orwell", AssignedCountryId = 3 },
            new Person { Name = "Douglas", LastName = "Adams", AssignedCountryId = 4 }
            );

            context.Countries.AddOrUpdate(
             p => p.Country,
             new Countries { Country = "Belgium", City = "Brussels" },
             new Countries { Country = "Brazil", City = "Rio de Janeiro" },
             new Countries { Country = "Canada", City = "Toronto" },
             new Countries { Country = "Chile", City = "Santiago" }
             );
        }
    }
}
