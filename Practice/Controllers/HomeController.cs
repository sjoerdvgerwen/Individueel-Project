    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Practice.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConnectionStrings connectionStrings;
        private readonly IConfiguration configuration;
        public User user;


        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }
      

        public IActionResult Index()
        {
            string connectionstring = configuration.GetConnectionString("DefaultLoginConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand com = new SqlCommand("SELECT * FROM [User]", connection);
            var reader = com.ExecuteReader();
            List<User> users = new List<User>();

            while (reader.Read())
            {
                user = new User((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2));
                users.Add(user);
            }
            return View(users);     
        }

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
