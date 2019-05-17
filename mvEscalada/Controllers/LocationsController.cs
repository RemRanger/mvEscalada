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
        private readonly IRouteRepository routeRepository;

        public LocationsController(ILocationRepository locationRepository, IRouteRepository routeRepository)
        {
            this.locationRepository = locationRepository;
            this.routeRepository = routeRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Location> locations = this.locationRepository.GetLocations();

            LocationViewModel viewModel = new LocationViewModel()
            {
                Title = "Locations",
                Locations = locations.ToList(),
                Api = this.locationRepository.GetLocationsApi()
            };

            return View(viewModel);
        }

        public IActionResult Topo(long locationId)
        {
            IEnumerable<Route> routes = this.routeRepository.GetRoutes(locationId);

            RouteViewModel viewModel = new RouteViewModel()
            {
                Title = "Topo",
                Location = this.locationRepository.GetLocationById(locationId),
                Routes = routes.ToList(),
                Api = this.routeRepository.GetRoutesApi(locationId)
            };

            return View(viewModel);
        }
    }
}