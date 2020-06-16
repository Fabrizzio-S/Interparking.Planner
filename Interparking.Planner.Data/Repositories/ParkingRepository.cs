using System;
using System.Collections.Generic;
using System.Linq;

using Interparking.Planner.Data.Contracts.Interfaces;
using Interparking.Planner.Data.Contracts.Models;

namespace Interparking.Planner.Data.Mocks
{
    public class ParkingRepository : IParkingRepository
    {
        #region Varbales Declaration

        private readonly InterparkingPlannerDbContext interparkingPlannerDbContext;

        #endregion

        #region Constructor

        public ParkingRepository(InterparkingPlannerDbContext interparkingPlannerDbContext)
        {
            this.interparkingPlannerDbContext = interparkingPlannerDbContext;
        }

        #endregion

        #region IParkingRepository Implementation

        public IEnumerable<Parking> GetParkings(string searchTerm)
        {
            return interparkingPlannerDbContext.Parkings.Where(x => x.Name.Contains(searchTerm) || x.Description.Contains(searchTerm));
        }

        #endregion

    }
}
