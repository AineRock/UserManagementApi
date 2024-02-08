using DataAccess.IRepositories;
using DataAccess.Models;
using Moq;
using UserManagementApi.Controllers;
using Xunit;

namespace UserManagementApi.Tests
{
    public class UserControllerTests
    {
        private Mock<IUserRepository> _repositoryMock;

        public UserControllerTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task CreateUser_Ok()
        {
            var newUser = new User(){
                FirstName = "Aine",
                LastName = "Rock",
                Email = "ainerock@gmail.com"
            };

            var controller = new UserController(_repositoryMock.Object);

            var result = await controller.CreateUser(newUser);
            
            Assert.NotNull(result);
            _repositoryMock.Verify(repo => repo.AddUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
