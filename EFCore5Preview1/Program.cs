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

        static void Main(string[] args)
        {
            EFCore5Preview2();
        }
    }
}
