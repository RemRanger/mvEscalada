using Microsoft.AspNetCore.Mvc;
using mvEscalada.Models;
using mvEscalada.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace mvEscalada.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAttemptRepository attemptRepository;

        public HomeController(IAttemptRepository attemptRepository)
        {
            this.attemptRepository = attemptRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Attempt> attempts = this.attemptRepository.GetAttempts();

            HomeViewModel viewModel = new HomeViewModel()
            {
                Title = "Latest activity",
                AttemptGroups = attempts.GroupBy(a => new { a.SessionId, a.UserId }).Select(g => new AttemptGroup
                {
                    SessionId = g.Key.SessionId,
                    UserId = g.Key.UserId,
                    Attempts = g.ToList()
                }).ToList(),
                Api = this.attemptRepository.GetAttemptsApi()
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
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
