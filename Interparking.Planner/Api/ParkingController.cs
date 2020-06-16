using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using Interparking.Planner.Data.Contracts.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interparking.Planner.Api
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
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
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult SearchParkings(string q)
        {
            var parkings = parkingRepository.GetParkings(q).Select(x => new { value = x.Id, text = x.Name, parking = x });
            if (parkings?.Any() != true)
            {
                return NotFound();
            }
            return Ok(parkings);
        }
    }
}
