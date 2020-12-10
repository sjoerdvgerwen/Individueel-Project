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

        public IActionResult DeleteProduct(Product product)
        {
            List<Product> products = _productRepository.GetAllProducts();

            var viewModel = new DeleteProductViewModel
            {
                Products = products
            };

            return View(viewModel);
        }


        public IActionResult Delete (Guid productID)
        {
            
            DeleteProduct selectedProduct = _productRepository.Delete(productID);

            selectedProduct.ProductID = productID;

            return RedirectToAction("DeleteProduct", selectedProduct);
        }

        //Vraag productinformatie op
            public IActionResult GetProductDetails(Guid productID)
        {

            Product p = _productRepository.GetProductDetails(productID);

            ProductViewModel p2 = new ProductViewModel(p);

            return View("GetProductDetails", p2);
        }


        //List in index
        public IActionResult Index() 
        {
           List<Product> products = _productRepository.GetAllProducts();

            ViewBag.Products = products;
            return View();
        }
        
        //View CreateProduct.cshtml
        public IActionResult CreateProduct()
        {
            return View();
        }

        
        public IActionResult ProductList()
        {
            return View();
        }

        

        //Add Quantity in List
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
