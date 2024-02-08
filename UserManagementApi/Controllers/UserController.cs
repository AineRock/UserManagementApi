using DataAccess.Repositories;
using Domain.Entities;
using Domain.IRepositories;
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
                await _repository.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(user);
        }
    }
}
