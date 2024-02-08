using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerControllerOrder(1)]
    public class ProfileController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IProfileRepository _profileRepository;

        public ProfileController(IUserRepository userRepository, IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        [HttpPost("CreateProfile")]
        public async Task<IActionResult> CreateProfile(Profile profile, string email)
        {
            try
            {
                var userId = _userRepository.GetUserIdByEmail(email);

                if (userId != null)
                {
                    Profile newProfile = new Profile()
                    {
                        UserId = userId.Id,
                        ProfileName = profile.ProfileName,
                        ProfileDescription = profile.ProfileDescription
                    };

                    await _profileRepository.AddProfileAsync(newProfile);
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
        [HttpGet("GetAllProfiles")]
        public List<Profile> GetAllUsers()
        {
            try
            {
                return _profileRepository.GetAllProfiles();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
