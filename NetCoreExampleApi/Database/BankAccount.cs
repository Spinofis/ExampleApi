using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database
{
    public class BankAccount
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public decimal Balance { get; set; }
        public DateTime LastUpdateDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
