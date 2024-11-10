using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Fish.Repositories.Models;

namespace Fish.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        static ApplicationDbContext()
        {
            System.Data.Entity.SqlServer.SqlProviderServices.Instance.GetType();
        }

        public ApplicationDbContext() : base("FishDbConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ServiceModel> ServiceModels { get; set; }

        public DbSet<PublicMessage> PublicMessages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
