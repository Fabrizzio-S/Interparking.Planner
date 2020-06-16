using System.ComponentModel.DataAnnotations;

namespace Interparking.Planner.Data.Contracts.Models
{
    public class Point
    {
        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
