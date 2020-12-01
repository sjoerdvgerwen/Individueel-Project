using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Webapp.Models
{
    public class ProductViewModel 
    {
        public Guid ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }
        
        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        public int AddQuantity { get; set; }

        public int ReduceQuantity { get; set; }

    }
}
