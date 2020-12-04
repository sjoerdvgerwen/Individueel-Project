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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

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

        public IActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);
            
            var user = _userRepository.GetUserName(model.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            
            var password = _userRepository.GetUserName(model.Password);
            if (password == null)
            {
                ModelState.AddModelError("", "YOOO VERKEERD WACHTWOORD!");
                return View(model);
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
 
