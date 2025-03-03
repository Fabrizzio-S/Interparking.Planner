﻿using System.Collections.Generic;

namespace Interparking.Planner.Data.Contracts.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public IEnumerable<Point> WayPoints { get; set; }
    }
}
