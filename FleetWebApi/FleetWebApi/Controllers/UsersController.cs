using FleetWebApi.Models;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FleetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UsersViewModel user)
        {
            try
            {
                if (user == null)
                    return BadRequest();
                var createUser = await userRepository.CreateUser(user);
                return createUser;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new user");
            }
        }
    }
}
