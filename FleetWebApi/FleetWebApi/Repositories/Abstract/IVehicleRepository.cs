using FleetWebApi.Models;
using FleetWebApi.ViewModels;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Abstract
{
    public interface IVehicleRepository
    {
        Task<Vehicle> AddVehicle(VehicleViewModel vehicle);
        Task<Vehicle> RenewLicense(int vehicleId);
    }
}

