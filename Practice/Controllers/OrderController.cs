using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Entity;
using Warehouse.Application.Interfaces;
using Warehouse.Database.Repository;
using Warehouse.Webapp.Models;

namespace Warehouse.Webapp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public IActionResult Order()
        {
            return View();
        }
        
        public IActionResult GetAllProducts()
        {
            List<Order> products = _orderRepository.GetAllProducts();

            var viewModel = new OrderViewModel
                {Products = products};

            return View(viewModel);
        }
        
        
        
    }
}