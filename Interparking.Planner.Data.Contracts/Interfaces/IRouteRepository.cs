using Interparking.Planner.Data.Contracts.Models;
using System.Collections.Generic;

namespace Interparking.Planner.Data.Contracts.Interfaces
{
    public interface IRouteRepository
    {
        public Route AddRoute(Route route);
        public Route UpdateRoute(Route route);
        public IEnumerable<Route> GetRoutes();
        public Route GetRouteById(int id);
        public int Commit();
    }
}
