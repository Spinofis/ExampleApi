using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExampleApi.BusinessLogic
{
    public interface IEntityFrameworkTests
    {
        Task UpdateProduct(int productId, int quantity, int waitBeforeUpdateMs);
        Task AddAmount(int accountId, decimal amount, int waitBeforeUpdateMs);
    }
}
