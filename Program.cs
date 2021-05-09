using EntityFramework5.Data.Context;
using EntityFramework5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace EntityFramework5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            using var context = new EFContext(configuration);

            var jane = new User { Name = "Jane" };
            var john = new User { Name = "John" };

            var football = new Group { Name = "Football", Users = new List<User> { jane, john } };
            var movies = new Group { Name = "Movies", Users = new List<User> { jane } };

            context.AddRange(jane, john, football, movies);
            await context.SaveChangesAsync();

            WriteLine();

            var users = await context.Users.Where(u => u.Groups.Any(g => g.Name == "Movies")).ToListAsync();
            foreach (var user in users)
            {
                WriteLine($"User (Movie group): {user.Name}");
            }

            WriteLine();

            var oldTimers = await context.Users.Where(u => u.Memberships.Any(m => m.CreateDate > new DateTime(2000, 1, 1))).ToListAsync();
            foreach (var user in oldTimers)
            {
                WriteLine($"Old timer user: {user.Name}");
            }

            WriteLine();

            var books = await context.Books
                .Include(c => c.Author)
                .ToListAsync();

            foreach (var book in books)
            {
                WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author.Name}");
            }

            ReadKey();
        }
    }
}
