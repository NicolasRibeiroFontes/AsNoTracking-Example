using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsNoTracking_Example
{
    public class Context : DbContext
    {
        public Context() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());
        }

        public DbSet<User> Users { get; set; }
    }
}
