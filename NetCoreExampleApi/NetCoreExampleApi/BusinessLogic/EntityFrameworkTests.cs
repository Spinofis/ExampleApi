using Database;
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

        public async Task TestConccurencyUpdate(decimal amount, int WaitBeforeUpdateMs)
        {
            try
            {
                BankAccount bankAccount = dbContext.BankAccount.First();
                bankAccount.Balance += amount;
                await Task.Delay(WaitBeforeUpdateMs);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {

            }
        }
    }
}
