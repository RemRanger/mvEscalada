using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvEscalada.Models;
using mvEscalada.ViewModels;

namespace mvEscalada.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<User> Users = this.userRepository.GetUsers();

            UserViewModel viewModel = new UserViewModel()
            {
                Title = "Climbers",
                Users = Users.ToList(),
                Api = this.userRepository.GetUsersApi()
            };

            return View(viewModel);
        }
    }
}