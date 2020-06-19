using System.Linq;

using Interparking.Planner.Data.Contracts.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Interparking.Planner.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        #region Variables Declaration

        private readonly IParkingRepository parkingRepository;

        #endregion

        #region Constructor

        public ParkingController(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        #endregion

        #region Business

        [HttpGet]
        public IActionResult SearchParkings(string q)
        {
            var parkings = parkingRepository.GetParkings(q).Select(x => new { value = x.Id, text = x.Name, parking = x });
            if (parkings?.Any() != true)
            {
                return NotFound();
            }
            return Ok(parkings);
        }

        #endregion
    }
}
