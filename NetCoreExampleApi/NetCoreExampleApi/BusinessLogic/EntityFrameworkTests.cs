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
    }
}
