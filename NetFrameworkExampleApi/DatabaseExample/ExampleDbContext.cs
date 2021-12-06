using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext() : base("ExampleDbConnectionString") { }

        public List<BankAccount> BankAccounts { get; set; }
    }
}
