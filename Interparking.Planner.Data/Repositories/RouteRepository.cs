using Interparking.Planner.Data.Contracts.Interfaces;
using Interparking.Planner.Data.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Interparking.Planner.Data.Mocks
{
    public class RouteRepository : IRouteRepository
    {
        #region Varbales Declaration

        private readonly InterparkingPlannerDbContext interparkingPlannerDbContext;

        #endregion

        #region Constructor

        public RouteRepository(InterparkingPlannerDbContext interparkingPlannerDbContext)
        {
            this.interparkingPlannerDbContext = interparkingPlannerDbContext;
        }

        #endregion

        #region IRouteRepository Implementation

        public int Commit()
        {
            return interparkingPlannerDbContext.SaveChanges();
        }

        public Route GetRouteById(int id)
        {
            return interparkingPlannerDbContext.Routes.Include(x => x.WayPoints).Include(x => x.EndPoint).Include(x => x.StartPoint).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Route> GetRoutes()
        {
            return interparkingPlannerDbContext.Routes.Include(x => x.WayPoints).Include(x => x.EndPoint).Include(x => x.StartPoint);
        }

        public Route AddRoute(Route route)
        {
            interparkingPlannerDbContext.Routes.Add(route);
            return route;
        }

        public Route UpdateRoute(Route route)
        {
            var existingRoute = interparkingPlannerDbContext.Routes.FirstOrDefault(x => x.Id == route.Id);
            if (existingRoute != null)
            {
                existingRoute.Name = route.Name;
                existingRoute.StartPoint = route.StartPoint;
                existingRoute.EndPoint = route.EndPoint;
                existingRoute.WayPoints = route.WayPoints;
            }
            return existingRoute;
        }

        #endregion
    }
}
