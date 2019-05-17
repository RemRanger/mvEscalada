using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvEscalada.Models;
using mvEscalada.ViewModels;

namespace mvEscalada.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationRepository locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Location> locations = this.locationRepository.GetLocations();

            LocationViewModel viewModel = new LocationViewModel()
            {
                Title = "Locations",
                Locations = locations.ToList()
            };

            return View(viewModel);
        }
    }
}