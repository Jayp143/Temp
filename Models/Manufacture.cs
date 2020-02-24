using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStore.Models
{
    public class Manufacture
    {
        [ForeignKey("ID")]
        public int ManufacturerID { get; set; }
        [Key]
        public String CompanyName { get; set; }
        public string ContactNumber { get; set; }

        public String CompanyDetails { get; set; }
    }
}
