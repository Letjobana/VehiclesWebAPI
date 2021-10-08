using FleetWebApi.Models;
using FleetWebApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Abstract
{
    public interface IVehicleRepository
    {
        Task<Vehicle> AddVehicle(VehicleViewModel vehicle);
        Task<Vehicle> RenewLicense(RenewLicenseViewModel renew);
        Task<IEnumerable<Vehicle>> GetVehicles(VehiclesParameters vehiclesParameters, string VIN = null, string model = null,
                                              string licenseNumber = null, string registrationPlate = null, string color = null);
    }
}

