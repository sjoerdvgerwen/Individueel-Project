using System.Collections.Generic;
using Warehouse.Application.Entity;

namespace Warehouse.Application.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetAllProducts();
    }
}