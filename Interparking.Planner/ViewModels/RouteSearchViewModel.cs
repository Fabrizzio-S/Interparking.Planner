using Microsoft.AspNetCore.Mvc;
using Interparking.Planner.Contracts.Models;

namespace Interparking.Planner.ViewModels
{
    public class RouteSearchViewModel
    {
        [BindProperty]
        public Route Route { get; set; }
    }
}
