using FleetWebApi.Models;
using FleetWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Abstract
{
    public interface IVehicleRepository
    {
        Task<Vehicle> AddVehicle(VehicleViewModel vehicle);
    }
}

