using Interparking.Planner.Data.Contracts.Interfaces;
using Interparking.Planner.Data.Contracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace Interparking.Planner.Data.Mocks
{
    public class MockRouteRepository : IRouteRepository
    {
        #region Variables Declarations

        List<Route> routes;

        #endregion

        #region Constructor

        public MockRouteRepository()
        {
            routes = new List<Route>()
            {
                new Route(){ Id = 1, StartPoint = new Point(){ Latitude = "50.838497", Longitude = "4.361148" }, EndPoint = new Point() { Latitude = "50.897399", Longitude = "4.481088" }, Name = "Route de Fab" }
            };
        }

        #endregion

        #region IRouteRepository Implementation

        public int Commit()
        {
            return 1;
        }

        public Route GetRouteById(int id)
        {
            return routes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Route> GetRoutes()
        {
            return routes;
        }

        public Route AddRoute(Route route)
        {
            route.Id = routes.Max(x => x.Id) + 1;
            routes.Add(route);
            return route;
        }

        public Route UpdateRoute(Route route)
        {
            var existingRoute = routes.FirstOrDefault(x => x.Id == route.Id);
            if(existingRoute != null)
            {
                existingRoute.Name = route.Name;
                //existingRoute.StartPoint = route.StartPoint;
                //existingRoute.EndPoint = route.EndPoint;
                existingRoute.WayPoints = route.WayPoints;
            }
            return existingRoute;
        }

        #endregion
    }
}
