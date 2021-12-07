using DatabaseExample;
using System;
using System.Collections.Generic;
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

        public async Task TestConccurencyUpdate(decimal amount, int WaitBeforeUpdateMs)
        {
            try
            {
                BankAccount bankAccount = dbContext.BankAccounts.First();
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