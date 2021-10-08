using FleetWebApi.Models;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FleetWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }
        [HttpPost]
        public async Task<ActionResult<Vehicle>> AddNewVehicle([FromBody] VehicleViewModel vehicle)
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
        [HttpPost]
        public async Task<ActionResult<Vehicle>> RenewLicense([FromBody] RenewLicenseViewModel renew)
        {
            try
            {
                var renewLicense = await vehicleRepository.RenewLicense(renew);
                return renewLicense;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
