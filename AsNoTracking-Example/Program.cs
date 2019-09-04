using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsNoTracking_Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();

            using (var ctx = new Context())
            {
                Example1(userService, ctx);
            }
        }

        private static void Example1(UserService userService, Context ctx)
        {
            for (int i = 0; i < 100; i++)
            {
                User user = new User() { Name = "Nicolas"+i };
                userService.Save(ctx, user);
            }
            ctx.SaveChanges();

            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture));
            Console.WriteLine("Users: " + String.Join(",", userService.GetNames(ctx)));
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture));
            Console.WriteLine("Users: " + String.Join(",", userService.GetNamesNoTracking(ctx)));
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture));

            userService.DeleteAll(ctx);
            ctx.SaveChanges();

            Console.ReadKey();
        }

        private static void Example2(UserService userService, Context ctx)
        {
            ////Run1 - Save Users
            //User user1 = new User() { Name = "Nicolas" };
            //Console.WriteLine("Save User: " + userService.Save(ctx, user1));
            //User user2 = new User() { Name = "Mr Fontes" };
            //Console.WriteLine("Save User: " + userService.Save(ctx, user2));
            //ctx.SaveChanges();
            //Console.WriteLine("Users: " + String.Join(",", userService.GetNames(ctx)));

            //Run2 - Get and Update User
            Console.WriteLine("Update User: " + userService.UpdateFirst(ctx));

            Console.ReadKey();
        }
    }
}
