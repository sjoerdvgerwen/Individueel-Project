using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Webapp.Models;
using Warehouse.Application.Entity;
using Warehouse.Application.Interfaces;

namespace Warehouse.Webapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Connectie van View Controller naar Application Interfaces
        public IActionResult Index()
        {
           List<Product> products = _productRepository.GetAllProducts();

            ViewBag.Products = products;
            return View();
        }

    //        public async Task<IActionResult> GetProduct(ProductViewModel product)
   //     {
    //        Product Products = new Product()
    //        {
                
     
         


        public IActionResult CreateProduct()
        {
            return View();
        }

        public IActionResult DeleteProduct()
        {
            return View();
        }


        public IActionResult GetProductDetails(ProductViewModel product)
        {
            Product GetProduct = new Product()
            {
                ProductID = product.ProductID
            };

            _productRepository.GetProductDetails(GetProduct);

            return RedirectToAction("GetProductDetails");
        }

        
        public IActionResult AddQuantity(ProductViewModel product)
        {
            Product ModifiedProduct = new Product()
            {
                AddQuantity = product.AddQuantity,
                ProductID = product.ProductID
            };

            _productRepository.AddQuantity(ModifiedProduct);
            return RedirectToAction("Index");

        }


            public IActionResult ReduceQuantity(ProductViewModel product)
        {
            Product reduceQuantity= new Product()
            {
                ReduceQuantity = product.ReduceQuantity,
                ProductID = product.ProductID
            };
            _productRepository.ReduceQuantity(reduceQuantity);
            return RedirectToAction("Index");

        }

        public IActionResult GetProductDetails()
        {
            return View();
        }


        // Methode voegt product toe, neemt de waardes over uit ViewModel, en maakt instantie van de klasse.
        public IActionResult AddProduct(ProductViewModel product) 
        {
            Product newProduct = new Product()
            {
                ProductID = Guid.NewGuid(),
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductQuantity = product.ProductQuantity
            };

            _productRepository.AddProduct(newProduct);
            
            return RedirectToAction("Index");   
        }
    }
}
