using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExampleApi.BusinessLogic
{
    public interface IEntityFrameworkTests
    {
        Task TestConccurencyUpdate(decimal amount, int waitBeforeUpdateMs);
    }
}
