using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(Name = "AddUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                await _repository.AddUserAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok("Please create profile");
        }
    }
}
