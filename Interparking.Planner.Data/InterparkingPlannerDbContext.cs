using Interparking.Planner.Data.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Interparking.Planner.Data
{
    public class InterparkingPlannerDbContext : DbContext
    {
        #region Constructor

        public InterparkingPlannerDbContext(DbContextOptions<InterparkingPlannerDbContext> options) : base(options)
        {

        }

        #endregion

        public DbSet<Route> Routes { get; set; }
        public DbSet<Parking> Parkings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Parking>().HasData(new Parking() { Id = 1, Address = "bvd de Waterloo 2a, 1000 Bruxelles", Description = "Le parking se situe en plein cœur d'un quartier commercial et du cinéma UGC Toison d'Or.", DisabledSpaces = 32, MaxHeight = 2.1M, Name = "2 Portes (Bruxelles)", Spaces = 719, Latitude = "50.838497", Longitude = "4.361148" });
            modelBuilder.Entity<Parking>().HasData(new Parking() { Id = 2, Address = "Place de la Justice 16, 1000 Bruxelles", Description = "Le parking se situe sous le Square, lieu d'évènements innombrables. Il est également à deux pas du Palais des Beaux Arts, du Musée Magritte et du Musée des Instruments de Musique.", DisabledSpaces = 15, MaxHeight = 2M, Name = "Albertine-Square (Bruxelles)", Spaces = 714, Latitude = "50.843919", Longitude = "4.354608" });
            modelBuilder.Entity<Parking>().HasData(new Parking() { Id = 3, Address = "Brussels Airport, 1930 Zaventem", Description = "Le parking se trouve en face du terminal de départ de Brussels Airport.\r\n\r\nParfait pour l'homme d'affaires qui arrive juste à temps pour le check in.\r\n\r\nPour y accéder, entrez dans le parking P1 Front et suivez les indications Fast Zone.", DisabledSpaces = 3, MaxHeight = 2.1M, Name = "P1 Fast Zone level 3 (Zaventem)", Spaces = 166, Latitude = "50.897399", Longitude = "4.481088" });
        }
    }
}
