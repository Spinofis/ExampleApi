using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample
{
    public class ExampleContext : DbContext
    {
        public ExampleContext() : base("ExampleDbConnectionString") { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
