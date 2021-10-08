using FleetWebApi.Models;
using FleetWebApi.Persistace;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FleetWebApi.Repositories.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext dbContext;
        public AccountRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Account> Deposite(AccountViewModel account)
        {
            try
            {
                Account acc = dbContext.Accounts.Where(r => r.UserId == account.UserId).FirstOrDefault();
                acc.Balance += account.Amount;
                await dbContext.SaveChangesAsync();
                return acc;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
