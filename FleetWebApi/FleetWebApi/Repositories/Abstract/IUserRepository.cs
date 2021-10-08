using FleetWebApi.Models;
using FleetWebApi.ViewModels;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<User> CreateUser(UsersViewModel user);
    }
}
