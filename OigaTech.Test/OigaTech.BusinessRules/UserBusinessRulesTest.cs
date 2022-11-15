using Moq;
using OigaTech.BusinessRules;
using OigaTech.DataAccess.Repositories;
using OigaTech.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OigaTech.Test.OigaTech.BusinessRules
{
    public class UserBusinessRulesTest
    {

        [Fact]
        public async Task GetAll_GetSeveralUser()
        {
            ///Arrange
            var userRepository = new Mock<IUserRepository>();

            var response = new UserPaginatedResponse
            {
                Users = new List<UserDto> {
                    new UserDto{
                        FullName="Test1",
                        UserName="Test1",
                    },
                    new UserDto{
                        FullName="Test1",
                        UserName="Test1",
                    }
                }
            };

            userRepository.Setup(x => x.GetAll()).ReturnsAsync(response);
            var userBusinessRules = new UserBusinessRules(userRepository.Object);

            ///Act
            var result = await userBusinessRules.GetAll();

            //Assert
            Assert.NotNull(result.Users);
            Assert.True(result.Users.Any());
            Assert.Equal(result, response);

        }
    }
}
