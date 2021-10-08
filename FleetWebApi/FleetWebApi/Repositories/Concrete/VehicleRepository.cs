using FleetWebApi.Models;
using FleetWebApi.Persistace;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
using System;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Concrete
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext dbContext;
        public VehicleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Vehicle> AddVehicle(VehicleViewModel vehicle)
        {
            try
            {
                Vehicle newVehicle = new Vehicle
                {
                    AccountId = vehicle.AccountId,
                    Color = vehicle.Color,
                    LicenseExpiry = vehicle.LicenseExpiry,
                    LicenseNumber = vehicle.LicenseNumber,
                    Model = vehicle.Model,
                    RegistrationPlate = vehicle.RegistrationPlate,
                    VIN = vehicle.VIN

                };
                var entity = await dbContext.Vehicles.AddAsync(newVehicle);
                await dbContext.SaveChangesAsync();
                return entity.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
