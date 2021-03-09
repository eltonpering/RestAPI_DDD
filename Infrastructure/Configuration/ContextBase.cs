using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) 
            : base(options)
        { }

        public ContextBase()
        { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AddressCustomer> AddressCustomer { get; set; }
        public DbSet<PhoneCustomer> PhoneCustomer { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }    


        private string GetStringConectionConfig()
        {
             string strCon = "Data Source=LAPTOP-L03EIPVD;Initial Catalog=RESTAPI_DB;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";          
            return strCon;
        }


    }
}
