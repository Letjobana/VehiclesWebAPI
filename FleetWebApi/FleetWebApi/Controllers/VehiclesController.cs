using FleetWebApi.Models;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FleetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }
        [HttpPost("AddVehicle")]
        public async Task<ActionResult<Vehicle>> CreateUser([FromBody] VehicleViewModel vehicle)
        {
            try
            {
                if (vehicle == null)
                    return BadRequest();
                var addVehicle = await vehicleRepository.AddVehicle(vehicle);
                return addVehicle;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error adding new vehicle");
            }
        }
    }
}
