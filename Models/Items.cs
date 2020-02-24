using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStore.Models
{
    public class Items
    {
        [Key]
        public int ID { get; set; }

        public int ProductId { get; set; }

        public String ProductName { get; set; }

        public int productprice { get; set; }
        public String Details { get; set; }
    }
}
