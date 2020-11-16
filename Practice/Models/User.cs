using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }


        public User(int userid, string username, string password)
        {
            UserID = userid;
            Username = username;
            Password = password;
        }
    }
}
