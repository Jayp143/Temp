using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStore.Models
{
    public class Items
    {
        public Items() {


            ProductName = "";
            Details = "";


        }


        [Key]
        public int ID { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int productprice { get; set; }
        public string Details { get; set; }
    }
}
