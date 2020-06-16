using Interparking.Planner.Data.Contracts.Models;

using Microsoft.AspNetCore.Mvc;

namespace Interparking.Planner.ViewModels
{
    public class RouteSearchViewModel
    {
        [BindProperty]
        public Route Route { get; set; }
    }
}
