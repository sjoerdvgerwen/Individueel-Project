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
   public class UserRepository : IUserRepository
    {
        private readonly MySqlConnection _con;


        // ??
        public UserRepository(MySqlConnection con)
        {
            _con = con;
        }

        public async Task<User> AddUser(User user)
        {
            await _con.OpenAsync();

            string query = "INSERT INTO User (UserID, Username, Password) VALUES(@ID, @User, @Pass)";
            var command = new MySqlCommand(query, _con);

            command.Parameters.AddWithValue("@ID", user.UserID);
            command.Parameters.AddWithValue("@User", user.UserName);
            command.Parameters.AddWithValue("@Pass", user.Password);

            command.ExecuteNonQuery();

            await _con.CloseAsync();

            return user;

        }
    }
}
