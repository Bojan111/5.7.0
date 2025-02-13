using System.Linq;
using TestDBTest.EntityFramework;
using TestDBTest.MultiTenancy;

namespace TestDBTest.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly TestDBTestDbContext _context;

        public DefaultTenantCreator(TestDBTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
