using FleetWebApi.Models;
using FleetWebApi.Persistace;
using FleetWebApi.Repositories.Abstract;
using System;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
