using DataAccess.IRepositories;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserManagementApi.Controllers
{
    public class ProfileController : Controller
    {
        private IUserRepository _userRepository;
        private IProfileRepository _profileRepository;

        public ProfileController(IUserRepository userRepository, IProfileRepository profileRepository)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
        }

        [HttpPost(Name = "AddProfile")]
        public async Task<IActionResult> CreateProfile([FromBody] Profile profile)
        {
            try
            {
                var userId = _userRepository.GetUserIdByEmail(profile.Email);

                if (userId != null)
                {
                    await _profileRepository.AddProfileAsync(
                        new Profile()
                        {
                            UserId = userId.Id,
                            ProfileName = profile.ProfileName,
                            ProfileDescription = profile.ProfileDescription
                        });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(profile);
        }
    }
}
