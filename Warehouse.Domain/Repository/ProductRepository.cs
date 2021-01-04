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
        
        public ProductRepository(MySqlConnection con)
        {
            _con = con;
        }

        MySqlDataReader datareader;
        List<Product> products = new List<Product>();


        public Product AddProduct(Product product)
        {
            _con.Open();

            string query =
                "INSERT INTO Product (ProductID, ProductName, ProductDescription, ProductQuantity) VALUES(@Id, @Name, @Des, @Quan)";
            var command = new MySqlCommand(query, _con);

            command.Parameters.AddWithValue("@Id", product.ProductID);
            command.Parameters.AddWithValue("@Name", product.ProductName);
            command.Parameters.AddWithValue("@Des", product.ProductDescription);
            command.Parameters.AddWithValue("@Quan", product.ProductQuantity);

            command.ExecuteNonQuery();

            _con.Close();

            return product;
        }


        public List<Product> GetAllProducts()
        {
            if (products.Count > 0)
            {
                products.Clear();
            }

            string query = "SELECT ProductID, ProductName, ProductDescription, ProductQuantity FROM Product";
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
                        ProductID = Guid.Parse(datareader["ProductID"].ToString()),
                        ProductName = datareader["ProductName"].ToString(),
                        ProductDescription = datareader["ProductDescription"].ToString(),
                        ProductQuantity = (datareader.GetInt32("ProductQuantity"))
                    });
                }

                datareader.Close();
                _con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return products;
        }


        public Product AddQuantity(Product product)
        {
            _con.Open();

            string query = "UPDATE product SET ProductQuantity = ProductQuantity + @Quantity WHERE ProductID=@id";
            var command = new MySqlCommand(query, _con);
            command.Parameters.AddWithValue("@id", product.ProductID);
            command.Parameters.AddWithValue("@Quantity", product.AddQuantity);


            command.ExecuteNonQuery();

            _con.Close();

            return product;
        }

        public Product ReduceQuantity(Product product)
        {
            _con.Open();

            string query = "UPDATE product SET ProductQuantity = ProductQuantity - @Quantity WHERE ProductID=@id";
            var command = new MySqlCommand(query, _con);
            command.Parameters.AddWithValue("@id", product.ProductID);
            command.Parameters.AddWithValue("@Quantity", product.ReduceQuantity);


            command.ExecuteNonQuery();

            _con.Close();

            return product;
        }

        public DeleteProduct Delete(Guid productID)
        {
            _con.Open();

            string query = "DELETE FROM product WHERE ProductID=@id;";
            var command = new MySqlCommand(query, _con);

            DeleteProduct deleteProduct = new DeleteProduct();
            deleteProduct.ProductID = productID;

            command.Parameters.AddWithValue(@"id", deleteProduct.ProductID);

            command.ExecuteNonQuery();

            _con.Close();

            return deleteProduct;
        }

        public Product GetProductDetails(Guid ProductID)
        {
            _con.Open();

            string query =
                "SELECT ProductID, ProductName, ProductDescription, ProductQuantity FROM Product WHERE ProductID=@id";
            var command = new MySqlCommand(query, _con);

            command.Parameters.AddWithValue(@"id", ProductID.ToString());

            MySqlDataReader reader = command.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {
                product.ProductID = new Guid(reader["ProductID"].ToString());
                product.ProductName = reader["ProductName"].ToString();
                product.ProductDescription = reader["ProductDescription"].ToString();
                product.ProductQuantity = (reader.GetInt32("ProductQuantity"));
            }

            reader.Close();
            _con.Close();

            return product;
        }

        public void AddBarcodeQuantity(string barcodeId)
        {
            int AddQuantity = 1;
            _con.Open();
            

            string query = "UPDATE product SET ProductQuantity = ProductQuantity + @Quantity WHERE BarcodeID=@id";
            var command = new MySqlCommand(query, _con);
            command.Parameters.AddWithValue("@id", barcodeId);
            command.Parameters.AddWithValue("@Quantity", AddQuantity);
            
            command.ExecuteNonQuery();

            _con.Close();
            
        }

        public void DecreaseBarcodeQuantity(string barcodeId)
        {
            
        }
    }
}