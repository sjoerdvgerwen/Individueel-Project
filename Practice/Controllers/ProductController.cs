using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Webapp.Models;
using Warehouse.Application.Entity;
using Warehouse.Application.Interfaces;
using Warehouse.Webapp.Views.Product;

namespace Warehouse.Webapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult DeleteProduct()
        {
            List<Product> products = _productRepository.GetAllProducts();

            var viewModel = new DeleteProductViewModel {Products = products};

            return View(viewModel);
        }

        public IActionResult Delete(Guid productId)
        {
            DeleteProduct selectedProduct = _productRepository.Delete(productId);

            selectedProduct.ProductID = productId;

            return RedirectToAction("DeleteProduct", selectedProduct);
        }

        public IActionResult GetProductDetails(Guid productId)
        {
            Product product = _productRepository.GetProductDetails(productId);

            ProductDetailsViewModel productModel = new ProductDetailsViewModel(product);

            return View("GetProductDetails", productModel);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
        
        public IActionResult BarcodeScanner()
        {
            return View();
        }
        
        public IActionResult GetUpdatedBarcodeProduct(string newBarcodeId)
        {
            _productRepository.AddBarcodeQuantity(newBarcodeId);
            Product product = _productRepository.GetProductByBarcode(newBarcodeId);
            NewProductViewModel viewmodel = new NewProductViewModel()
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductQuantity = product.ProductQuantity
            };
            
            return View(viewmodel);
        }

        public IActionResult AddBarcodeQuantity(string barcodeId)
        {
            _productRepository.AddBarcodeQuantity(barcodeId);
            
            return RedirectToAction("GetUpdatedBarcodeProduct", new {newBarcodeId = barcodeId});
        }
        
        public IActionResult DecreaseBarcodeQuantity(string barcodeId)
        {
            _productRepository.DecreaseBarcodeQuantity(barcodeId);
            
            return RedirectToAction("GetUpdatedBarcodeProduct", new {newBarcodeId = barcodeId});
        }

        public IActionResult ProductList()
        {
            List<Product> products = _productRepository.GetAllProducts();

            var productList = new ProductListViewModel() {ProductList = products};
            return View(productList);
        }

        
        public IActionResult AddQuantity(AddProductViewModel product)
        {
            Product modifiedProduct = new Product() {AddQuantity = product.AddQuantity, ProductID = product.ProductID};

            _productRepository.AddQuantity(modifiedProduct);
            return RedirectToAction("ProductList");
        }

        public IActionResult ReduceQuantity(ReduceProductViewModel product)
        {
            Product reduceQuantity = new Product()
            {
                ReduceQuantity = product.ReduceQuantity, ProductID = product.ProductID
            };
            _productRepository.ReduceQuantity(reduceQuantity);
            return RedirectToAction("ProductList");
        }

        public IActionResult AddProduct(NewProductViewModel product)
        {
            Product newProduct = new Product()
            {
                ProductID = Guid.NewGuid(),
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductQuantity = product.ProductQuantity,
                BarcodeId = product.BarcodeId
            };

            _productRepository.AddProduct(newProduct);

            return RedirectToAction("ProductList");
        }
    }
}
