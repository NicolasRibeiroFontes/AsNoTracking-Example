using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsNoTracking_Example
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(u => u.ID);

            Property(u => u.Name)
               .IsRequired()
               .HasMaxLength(100);
        }
    }
}
