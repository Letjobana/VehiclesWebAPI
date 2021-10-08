using FleetWebApi.Models;
using FleetWebApi.Persistace;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<Vehicle> RenewLicense(RenewLicenseViewModel renew)
        {

            try
            {
                Vehicle vehicle = dbContext.
                    Vehicles.Include(r => r.Account).
                    Where(r => r.Id == renew.VehicleId).FirstOrDefault();

                if (vehicle.Account.Balance - 500 < 0)
                {
                    throw new InvalidOperationException("Insufficient fund");

                }
                vehicle.LicenseExpiry = vehicle.LicenseExpiry.AddYears(1);
                vehicle.Account.Balance -= 500;
                await dbContext.SaveChangesAsync();
                return vehicle;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

