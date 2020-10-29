using System.Data.Common;
using System.Data.Entity;
using Abp.DynamicEntityProperties;
using Abp.EntityFramework;
using Abp.Zero.EntityFramework;
using TestDBTest.Authorization.Roles;
using TestDBTest.Authorization.Users;
using TestDBTest.Entities;
using TestDBTest.MultiTenancy;

namespace TestDBTest.EntityFramework
{
    public class TestDBTestDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public virtual IDbSet<Task> Tasks { get; set; }
        public virtual IDbSet<Countries> Countries { get; set; }
        public virtual IDbSet<Person> People { get; set; }
        public virtual IDbSet<TypeOfApplication> TypeOfApplication { get; set; }
        public virtual IDbSet<NearMiss> NearMiss { get; set; }
        public virtual IDbSet<MedicalError> MedicalError { get; set; }
        public virtual IDbSet<MedicalDeviceInfo> MedicalDeviceInfo { get; set; }
        public virtual IDbSet<UseOfMedicalDevices> UseOfMedicalDevices { get; set; }
        public virtual IDbSet<OfficialGazzete> OfficialGazzete { get; set; }
        public virtual IDbSet<ManufacturerInfo> ManufacturerInfo { get; set; }
        public virtual IDbSet<ListOfInformation> ListOfInformation { get; set; }
        public TestDBTestDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TestDBTestDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TestDBTestDbContext since ABP automatically handles it.
         */
        public TestDBTestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TestDBTestDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public TestDBTestDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
