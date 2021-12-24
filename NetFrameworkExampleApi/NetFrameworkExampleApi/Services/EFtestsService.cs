using DatabaseExample;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NetFrameworkExampleApi.BL
{
    public class EFtestsService
    {
        private ExampleContext dbContext;

        public EFtestsService()
        {
            dbContext = new ExampleContext();
        }

        public async Task AddAmount(int bankAccountId, decimal amount, int waitBeforeUpdateMs)
        {
            try
            {
                BankAccount bankAccount = dbContext.BankAccounts.Where(x => x.Id == bankAccountId).First();
                bankAccount.Balance += amount;
                await Task.Delay(waitBeforeUpdateMs);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}