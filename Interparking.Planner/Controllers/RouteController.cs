using System.Collections.Generic;
using System.Linq;

using Interparking.Planner.Data.Contracts.Interfaces;
using Interparking.Planner.Data.Contracts.Models;
using Interparking.Planner.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Interparking.Planner.Controllers
{
    public class RouteController : Controller
    {
        #region Variables Declaration

        private readonly IParkingRepository parkingRepository;
        private readonly IRouteRepository routeRepository;

        #endregion

        #region Constructor

        public RouteController(IParkingRepository parkingRepository, IRouteRepository routeRepository)
        {
            this.parkingRepository = parkingRepository;
            this.routeRepository = routeRepository;
        }

        #endregion

        #region ActionMethods

        public ViewResult Search()
        {
            RouteSearchViewModel findRouteSearchViewModel = new RouteSearchViewModel();
            return View(findRouteSearchViewModel);
        }

        public ActionResult Edit(int routeId)
        {
            Route route = routeRepository.GetRouteById(routeId);
            if (route == null)
            {
                return RedirectToPage("./NotFound");
            }
            RouteEditViewModel routeEditViewModel = new RouteEditViewModel()
            {
                Route = route
            };
            return View(routeEditViewModel);
        }

        //public ActionResult Edit(int routeIndex, string startPointLatitude, string startPointLongitude, string endPointLatitude, string endPointLongitude)
        //{
        //    Route route = routeRepository.GetRouteById(routeId);
        //    if (route == null)
        //    {
        //        return RedirectToPage("./NotFound");
        //    }
        //    RouteEditViewModel routeEditViewModel = new RouteEditViewModel()
        //    {
        //        Route = route
        //    };
        //    return View(routeEditViewModel);
        //}

        [HttpPost]
        public ActionResult Edit()
        {
            Route route = Newtonsoft.Json.JsonConvert.DeserializeObject<Route>(Request.Form["Route"]);

            RouteEditViewModel routeEditViewModel = new RouteEditViewModel()
            {
                Route = route
            };
            return View(routeEditViewModel);
        }

        public ViewResult Resume()
        {
            RouteResumeViewModel routeResumeViewModel = new RouteResumeViewModel()
            {
                Routes = routeRepository.GetRoutes()
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
            if(findRouteSaveViewModel.Route.Id > 0)
            {
                routeRepository.UpdateRoute(findRouteSaveViewModel.Route);
            }
            else
            {
                routeRepository.AddRoute(findRouteSaveViewModel.Route);
            }
            routeRepository.Commit();
            return RedirectToAction("Resume");
            //Todo save datas
        }

        #endregion
    }
}
