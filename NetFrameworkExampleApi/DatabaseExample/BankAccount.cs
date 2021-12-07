using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample
{
    public class BankAccount
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public decimal Balance { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
