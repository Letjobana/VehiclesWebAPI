using FleetWebApi.Models;
using FleetWebApi.ViewModels;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Abstract
{
    public interface IAccountRepository
    {
        Task<Account> Deposite(AccountViewModel account);
    }
}
