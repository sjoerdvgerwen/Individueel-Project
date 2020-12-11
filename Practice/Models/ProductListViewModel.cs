using System;
using System.Collections.Generic;
using Warehouse.Application.Entity;

namespace Warehouse.Webapp.Models
{
    public class ProductListViewModel
    {
        public List<Product> ProductList = new List<Product>();
        public Guid ProductID { get; set; }
        public int AddQuantity { get; set; }

        public int ReduceQuantity { get; set; }
    }
}