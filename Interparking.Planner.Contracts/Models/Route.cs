using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interparking.Planner.Contracts.Models
{
    public class Route
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrer un nom de route!")]
        [Display(Name = "Nom de la route")]
        [StringLength(50)]
        public string Name { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public IEnumerable<Point> WayPoints { get; set; }
    }
}
