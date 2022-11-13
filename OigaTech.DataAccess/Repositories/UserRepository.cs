using OigaTech.DataAccess.Models;
using OigaTech.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OigaTech.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OigaTechDBContext _dbContext;
        public UserRepository(OigaTechDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(UserDto user)
        {
            try
            {
                _dbContext.User.Add(new User { FullName = user.FullName, UserName = user.UserName });
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidateUserName(string userName)
        {
            return _dbContext.User.Where(x => x.UserName == userName).Any();
        }
    }
}
