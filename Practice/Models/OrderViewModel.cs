using System.Collections.Generic;
using Warehouse.Application.Entity;

namespace Warehouse.Webapp.Models
{
    public class OrderViewModel
    {
        public List<Order> Products { get; set; } = new List<Order>();
    }
}