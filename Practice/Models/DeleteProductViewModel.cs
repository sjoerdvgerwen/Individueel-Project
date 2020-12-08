using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Application.Entity;

namespace Warehouse.Webapp.Models
{
    public class DeleteProductViewModel
    {
        public List<Product> Products { get; set; }

        public string ProductToDeleteId { get; set; }
    }

}
