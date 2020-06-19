using System.Collections.Generic;
using AutoMapper;
using Interparking.Planner.Contracts.Models;
using Interparking.Planner.Data.Contracts.Interfaces;
using RouteData = Interparking.Planner.Data.Contracts.Models.Route;
using Interparking.Planner.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Interparking.Planner.Controllers
{
    public class RouteController : Controller
    {
        #region Variables Declaration

        private readonly IRouteRepository routeRepository;
        private readonly IMapper mapper;

        #endregion

        #region Constructor

        public RouteController(IRouteRepository routeRepository, IMapper mapper)
        {
            this.routeRepository = routeRepository;
            this.mapper = mapper;
        }

        #endregion

        #region ActionMethods

        public ViewResult Search()
        {
            var findRouteSearchViewModel = new RouteSearchViewModel();
            return View(findRouteSearchViewModel);
        }

        public ActionResult Edit(int routeId)
        {
            Route route = mapper.Map<RouteData, Route>(routeRepository.GetRouteById(routeId));
            if (route == null)
            {
                return RedirectToPage("./NotFound");
            }
            var routeEditViewModel = new RouteEditViewModel()
            {
                Route = route
            };
            return View(routeEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            Route route = Newtonsoft.Json.JsonConvert.DeserializeObject<Route>(Request.Form["Route"]);

            var routeEditViewModel = new RouteEditViewModel()
            {
                Route = route
            };
            return View(routeEditViewModel);
        }

        public ViewResult Resume()
        {
            var routeResumeViewModel = new RouteResumeViewModel()
            {
                Routes = mapper.Map<IEnumerable<RouteData>, IEnumerable<Route>>(routeRepository.GetRoutes())
            };
            return View(routeResumeViewModel);
        }

        [HttpPost]
        public ActionResult Resume(RouteEditViewModel findRouteSaveViewModel)
        {
            List<Point> wayPoints = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Point>>(Request.Form["Route.WayPoints"]);
            findRouteSaveViewModel.Route.WayPoints = wayPoints;
            if (!ModelState.IsValid)
            {
                return View(findRouteSaveViewModel);
            }
            if (findRouteSaveViewModel.Route.Id > 0)
            {
                routeRepository.UpdateRoute(mapper.Map<Route, RouteData>(findRouteSaveViewModel.Route));
            }
            else
            {
                routeRepository.AddRoute(mapper.Map<Route, RouteData>(findRouteSaveViewModel.Route));
            }
            routeRepository.Commit();
            return RedirectToAction("Resume");
        }

        #endregion
    }
}
