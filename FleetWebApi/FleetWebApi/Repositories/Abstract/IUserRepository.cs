using FleetWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
    }
}
