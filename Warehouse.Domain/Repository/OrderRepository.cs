using System;
using System.Collections.Generic;
using MySqlConnector;
using Warehouse.Application.Entity;
using Warehouse.Application.Interfaces;

namespace Warehouse.Database.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MySqlConnection _con;
        MySqlDataReader datareader;
        
        public OrderRepository(MySqlConnection con)
        {
            _con = con;
        }
        private List<Order> OrderDetails = new List<Order>();

        public List<Order> GetAllProducts() 
        {
            if (OrderDetails.Count > 0)
            {
                OrderDetails.Clear();
            }

            string query = "SELECT ProductID, ProductName FROM Product";
            var command = new MySqlCommand(query, _con);

            try
            {
                _con.Open();
                command.CommandText = query;
                datareader = command.ExecuteReader();


                while (datareader.Read())
                {
                    OrderDetails.Add(new Order()
                    {
                        ProductID = Guid.Parse(datareader["ProductID"].ToString()),
                        ProductName = datareader["ProductName"].ToString(),
                    });
                }

                datareader.Close();
                _con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return OrderDetails;
        }
    }
}