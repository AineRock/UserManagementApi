using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("AddProfile")]
        public async Task<IActionResult> CreateProfile(string profileName, string profileDescription,
            string email)
        {
            try
            {
                var userId = _userRepository.GetUserIdByEmail(email);

                    var newProfile =  await _profileRepository.AddProfileAsync(
                        new Profile()
                        {
                            UserId = (Int16)userId.Id,
                            ProfileName = profileName,
                            ProfileDescription = profileDescription
                        });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
    }
}
