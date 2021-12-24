using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ConcurrencyCheck]
        public int Quantity { get; set; }
    }
}
