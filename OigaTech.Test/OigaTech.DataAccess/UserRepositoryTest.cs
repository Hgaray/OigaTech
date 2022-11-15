using Microsoft.EntityFrameworkCore;
using OigaTech.DataAccess;
using OigaTech.DataAccess.Repositories;
using OigaTech.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OigaTech.Test.OigaTech.DataAccess
{
    public class UserRepositoryTest
    {
        [Fact]
        public async Task Add_NewUser_Successful()
        {
            var builder = new DbContextOptionsBuilder<OigaTechDBContext>();
            builder.UseInMemoryDatabase(databaseName: "OigaTechDB");
            var dbContextOption = builder.Options;

            var dbContext = new OigaTechDBContext(dbContextOption);

            var newUser = new UserDto
            {
                FullName="TestRepo",
                UserName="userName"
            };

            var repo = new UserRepository(dbContext);

            var result = await repo.Add(newUser);

            Assert.True(result);
        }
    }
}
