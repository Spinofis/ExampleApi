using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExampleApi.BusinessLogic
{
    public class EntityFrameworkTests : IEntityFrameworkTests
    {
        private readonly ExampleContext dbContext;

        public EntityFrameworkTests(ExampleContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task AddAmount(int bankAccountId, decimal amount, int waitBeforeUpdateMs)
        {
            try
            {
                BankAccount bankAccount = dbContext.BankAccount.Where(x => x.Id == bankAccountId).First();
                bankAccount.Balance += amount;
                bankAccount.LastUpdateDate = DateTime.Now;
                await Task.Delay(waitBeforeUpdateMs);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }

        public async Task UpdateProduct(int productId, int quantity, int waitBeforeUpdateMs)
        {
            try
            {
                Product product = dbContext.Product.Where(x => x.Id == productId).First();
                product.Quantity += quantity;
                await Task.Delay(waitBeforeUpdateMs);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }

        public async Task StreamingVsBuffering() 
        {
            // ToList and ToArray cause the entire resultset to be buffered:
            var blogsList = dbContext.Posts.TagWith("Query1").Where(p => p.Title.StartsWith("A")).ToList();
            var blogsArray = dbContext.Posts.TagWith("Query2").Where(p => p.Title.StartsWith("A")).ToArray();

            // Foreach streams, processing one row at a time:
            foreach (var blog in dbContext.Posts.TagWith("Query3").Where(p => p.Title.StartsWith("A")))
            {
                Console.WriteLine(blog.Content);
            }

            // AsEnumerable also streams, allowing you to execute LINQ operators on the client-side:
            var doubleFilteredBlogs = dbContext.Posts.TagWith("Query4")
                .Where(p => p.Title.StartsWith("A")) // Translated to SQL and executed in the database
                .AsEnumerable()
                .Where(p => true); // Executed at the client on all database results
        }
    }
}
