using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IProfileRepository _profileRepository;

        public ProfileController(IUserRepository userRepository, IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        [HttpPost(Name = "AddProfile")]
        public async Task<IActionResult> CreateProfile([FromBody] 
        string profileName, string profileDescription, string email)
        {
            try
            {
                var userId = _userRepository.GetUserIdByEmail(email);

                if (userId != null)
                {
                    var profile = await _profileRepository.AddProfileAsync(
                        new Profile()
                        {
                            UserId = userId.Id,
                            ProfileName = profileName,
                            ProfileDescription = profileDescription
                        });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
    }
}
