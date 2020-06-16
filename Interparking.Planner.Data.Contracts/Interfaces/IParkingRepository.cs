using System.Collections.Generic;

using Interparking.Planner.Data.Contracts.Models;

namespace Interparking.Planner.Data.Contracts.Interfaces
{
    public interface IParkingRepository
    {
        IEnumerable<Parking> GetParkings(string searchTerm);
    }
}