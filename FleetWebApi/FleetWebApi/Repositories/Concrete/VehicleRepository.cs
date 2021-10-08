using FleetWebApi.Models;
using FleetWebApi.Persistace;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Concrete
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext dbContext;
        private DbSet<Vehicle> dbset;
        public VehicleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbset = dbContext.Set<Vehicle>();
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

        public async Task<IEnumerable<Vehicle>> GetVehicles(VehiclesParameters vehiclesParameters, string VIN = null, string model = null,
            string licenseNumber = null, string registrationPlate = null, string color = null)
        {
            IQueryable<Vehicle> query = dbset;

            if (!string.IsNullOrEmpty(VIN))
            {
                query = query.Where(r => r.VIN == VIN);
            }
            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(r => r.Model == model);

            }
            if (!string.IsNullOrEmpty(licenseNumber))
            {
                query = query.Where(r => r.LicenseNumber == licenseNumber);

            }
            if (!string.IsNullOrEmpty(registrationPlate))
            {
                query = query.Where(r => r.RegistrationPlate == registrationPlate);

            }
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(r => r.Color == color);

            }
            return await query.OrderBy(x => x.Id).
                Skip((vehiclesParameters.pageNumber - 1) * vehiclesParameters.PageSize)
                .Take(vehiclesParameters.PageSize).ToListAsync();
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

