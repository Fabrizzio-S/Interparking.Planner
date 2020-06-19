using AutoMapper;
using Interparking.Planner.Contracts.Models;
using RouteData = Interparking.Planner.Data.Contracts.Models.Route;
using PointData = Interparking.Planner.Data.Contracts.Models.Point;

namespace Interparking.Planner.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Route, RouteData>();
            CreateMap<RouteData, Route>();
            CreateMap<Point, PointData>();
            CreateMap<PointData, Point>();
        }
    }
}
