using FleetWebApi.Models;
using FleetWebApi.Persistace;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
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
        public async Task<User> CreateUser(UsersViewModel user)
        {
            try
            {
                User users = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IdNumber = user.IdNumber,
                    Password = user.Password,
                    Email = user.Email,
                    Account = new Account
                    {
                        Balance = user.AccountBalance,

                    }
                };
                var result = await dbContext.Users.AddAsync(users);
                await dbContext.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
