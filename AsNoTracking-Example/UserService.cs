using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsNoTracking_Example
{
    public class UserService
    {
        public bool Save(Context ctx, User user)
        {
            ctx.Users.Add(user);

            return true;
        }

        public List<string> GetNames(Context ctx)
        {
            return ctx.Users.Select(x => x.Name).ToList();
        }

        public List<string> GetNamesNoTracking(Context ctx)
        {
            return ctx.Users.AsNoTracking().Select(x => x.Name).ToList();
        }

        public void DeleteAll(Context ctx)
        {
            foreach (var item in ctx.Users.ToList())
            {
                ctx.Users.Remove(item);
            }
            ctx.SaveChanges();
        }

        public bool UpdateFirst(Context ctx)
        {
            try
            {
                User user = ctx.Users.SingleOrDefault(x => x.Name == "Other Name");
                user.Name = "Name";
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        
    }
}
