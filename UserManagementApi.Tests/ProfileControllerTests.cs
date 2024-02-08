using DataAccess.IRepositories;
using DataAccess.Models;
using Moq;
using UserManagementApi.Controllers;
using Xunit;

namespace UserManagementApi.Tests
{
    public class ProfileControllerTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IProfileRepository> _profileRepositoryMock;


        public ProfileControllerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _profileRepositoryMock = new Mock<IProfileRepository>();
        }

        [Fact]
        public async Task CreateProfile_Ok()
        {
            string email = "test@test.com";

            Profile newProfile = new Profile()
            {
                UserId = 1,
                ProfileName = "Test",
                ProfileDescription = "TestDescription"
        };

            _userRepositoryMock.Setup(repo => repo.GetUserIdByEmail(It.IsAny<string>()))
                .Returns(It.IsAny<User>());

            _profileRepositoryMock.Setup(r => r.AddProfileAsync(It.IsAny<Profile>()))
                .ReturnsAsync(newProfile)
                .Verifiable();

            var controller = new ProfileController(_userRepositoryMock.Object, _profileRepositoryMock.Object);

            var result = await controller.CreateProfile(newProfile,email);

            Assert.NotNull(result);
            _userRepositoryMock.Verify(repo => repo.GetUserIdByEmail(It.IsAny<string>()), Times.Once);
            _profileRepositoryMock.Verify(repo => repo.AddProfileAsync(It.IsAny<Profile>()), Times.Once);

        }

        [Fact]
        public void GetAllProfiles_Ok()
        {

            var controller = new ProfileController(_userRepositoryMock.Object, _profileRepositoryMock.Object);

            var result = controller.GetAllUsers();

            _profileRepositoryMock.Verify(repo => repo.GetAllProfiles(), Times.Once);
        }
    }
}
