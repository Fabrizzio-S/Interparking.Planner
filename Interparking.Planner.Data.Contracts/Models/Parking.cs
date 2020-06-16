namespace Interparking.Planner.Data.Contracts.Models
{
    public class Parking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Spaces { get; set; }
        public int DisabledSpaces { get; set; }
        public decimal MaxHeight { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
