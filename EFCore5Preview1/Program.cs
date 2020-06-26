using EFCore5Preview1.Context;
using EFCore5Preview1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore5Preview1
{
    class Program
    {
        public static void EFCore5Preview1()
        {
            using var dbContext = new SampleDbContext();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Oktay Kır",
                Blog = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                CreateDate = DateTime.UtcNow,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Id = Guid.NewGuid(),
                        City = "İstanbul",
                        Zip = 34325,
                        Street = "Street"
                    }
                }
            };

            dbContext.Add(user);

            dbContext.SaveChanges();

            dbContext.Database.SetConnectionString("Server=127.0.0.1;Initial Catalog=master;User=sa;Password=Pass@word;");

            var query = dbContext.Set<User>().Where(c => c.Name == user.Name);
            Console.WriteLine(query.ToQueryString());

            var reversedUsers = dbContext.Set<User>().Where(c => c.Name == user.Name).Reverse();

            int count = dbContext.Users.Count(c => c.CreateDate > EF.Functions.DateFromParts(DateTime.Now.Year, 5, 25));
            Console.WriteLine(count);

            var blogs = dbContext.Users.Where(e => e.Blog.Contains((byte)234)).ToList();
        }

        public static void EFCore5Preview2()
        {
            using var dbContext = new SampleDbContext();

            var user = new Blog()
            {

            };
            user.SetTitle("title1");

            dbContext.Add(user);

            dbContext.SaveChanges();

            var blogs = dbContext.Blogs.ToList();
        }

        public static void EFCore5Preview3()
        {
            using var dbContext = new SampleDbContext();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Oktay Kır",
                Blog = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                CreateDate = DateTime.UtcNow,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Id = Guid.NewGuid(),
                        City = "Izmir",
                        Zip = 34325,
                        Street = "StreetIzmir"
                    },
                    new Address
                    {
                        Id = Guid.NewGuid(),
                        City = "İstanbul",
                        Zip = 34326,
                        Street = "StreetIstanbul"
                    },
                    new Address
                    {
                        Id = Guid.NewGuid(),
                        City = "Ankara",
                        Zip = 34327,
                        Street = "StreetAnkara"
                    }
                }
            };

            dbContext.Add(user);

            dbContext.SaveChanges();

            var query1 = dbContext
                .Users
                .Include(e => e.Addresses.Where(p => p.City.Contains("i")));

            Console.WriteLine(query1.ToQueryString());

            var query2 = dbContext.Users
                .Include(e => e.Addresses.OrderByDescending(post => post.City).Take(5));

            var count = dbContext.Users.Count(c => 5 > EF.Functions.DataLength(c.Name));

            Console.WriteLine(query2.ToQueryString());
        }

        public static void EFCore5Preview5()
        {
            using var dbContext = new SampleDbContext();

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Oktay Kır",
                Blog = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                Price = 12,
                CreateDate = DateTime.UtcNow
            };

            var address1 = new Address
            {
                    Id = Guid.NewGuid(),
                    City = "İstanbul",
                    Zip = 34325,
                    Street = "StreetIstanbul",
                    UserId = user.Id
            };

            var address2 = new Address
            {
                Id = Guid.NewGuid(),
                City = "İstanbul",
                Zip = 34325,
                Street = "StreetIstanbul",
                UserId = user.Id
            };

            dbContext.Add(user);
            dbContext.Add(address1);
            dbContext.Add(address2);

            dbContext.SaveChanges();

            //var getUsersQuery = dbContext
            //    .Users
            //    .Where(e => EF.Functions.Collate(e.Name, "Turkish_CI_AS") == "Oktay Kır");

            //Console.WriteLine(getUsersQuery.ToQueryString());

            var addresses = dbContext
                .Addresses
                .AsNoTracking()
                .PerformIdentityResolution()
                .Include(e => e.User)
                .ToList();

            addresses[0].User.Name = "modified";

            var computedUpdatedDateValue = addresses[0].User.UpdatedDate;
            var computedColumnValue = addresses[0].User.Computed;
        }

        static void Main(string[] args)
        {
            EFCore5Preview5();
        }
    }
}
