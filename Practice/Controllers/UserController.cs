using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Practice.Models;
using Warehouse.Application.Interfaces;
using Warehouse.Webapp.Models;
using Warehouse.Application.Entity;



namespace Practice.Controllers

    
{
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> AddUser(UserViewModel user) 
        { 
                Warehouse.Application.Entity.User Newuser =  new Warehouse.Application.Entity.User()
                {
                    UserID = Guid.NewGuid(),
                    UserName = user.UserName,
                    Password = user.Password
                };

            return Ok(await _userRepository.AddUser(Newuser));
        }
    }
}
 
