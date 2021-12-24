using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ConcurrencyCheck]
        public int Quantity { get; set; }
    }
}
