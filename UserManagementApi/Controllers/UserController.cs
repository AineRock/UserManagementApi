using DataAccess.IRepositories;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerControllerOrder(0)]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                await _repository.AddUserAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok("Please create a profile");
        }

        [HttpGet("GetAllUsers")]
        public List<User> GetAllUsers()
        {
            try
            {
                return _repository.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
