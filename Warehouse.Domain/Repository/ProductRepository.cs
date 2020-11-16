using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Entity;
using Warehouse.Application.Interfaces;

namespace Warehouse.Database.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlConnection _con;


        // ??
        public ProductRepository(MySqlConnection con)
        {
            _con = con;
        }

        MySqlDataReader datareader;
        List<Product> products = new List<Product>();

        public Product AddProduct(Product product)
        {
             _con.Open();

            string query = "INSERT INTO Product (ProductID, ProductName, ProductDescription) VALUES(@Id, @Name, @Des)";
            var command = new MySqlCommand(query, _con);

            command.Parameters.AddWithValue("@Id", product.ProductID);
            command.Parameters.AddWithValue("@Name", product.ProductName);
            command.Parameters.AddWithValue("@Des", product.ProductDescription);

            command.ExecuteNonQuery();

            _con.Close();

            return product;
        }

        //public async Task<Product> GetProducts(Product product) 
        public List<Product> GetAllProducts()
        {
            if (products.Count > 0)
            {
                products.Clear();
            }
            string query = "SELECT * FROM Product";
            var command = new MySqlCommand(query, _con);
            try
            {
                _con.Open();
                command.CommandText = query;
                datareader = command.ExecuteReader();


                while (datareader.Read())
                {

                    products.Add(new Product()
                    {
                        ProductName = datareader["ProductName"].ToString(),
                        ProductDescription = datareader["ProductDescription"].ToString()
                    });
                }
                _con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return products;
        }

  
    }
}

           

