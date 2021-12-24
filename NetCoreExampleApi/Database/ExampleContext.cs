using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class ExampleContext : DbContext
    {
        public ExampleContext(DbContextOptions<ExampleContext> options) : base(options) { }

        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
