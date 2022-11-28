using Microsoft.EntityFrameworkCore;
using OigaTech.DataAccess.Models;
using OigaTech.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public async Task<UserPaginatedResponse> GetAll()
        {
            try
            {

                var users = await _dbContext.User.Select(x => new UserDto
                {
                    UserId = x.UserId,
                    FullName = x.FullName,
                    UserName = x.UserName
                }).ToListAsync();

                var result = new UserPaginatedResponse
                {

                    Users = users,
                    PageIndex = 0,
                    TotalCount = users.Count(),
                    TotalPages = users.Any() ? Math.Ceiling((decimal)users.Count() / 10) : 0
                };

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

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
        public async Task<List<UserDto>> Search(string search)
        {
            try
            {
                var result = new List<UserDto>();

                if (!string.IsNullOrEmpty(search))
                {
                    string searchNoAccent = Regex.Replace(search.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
                    var words = searchNoAccent.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var query = words.Select(x =>
                    {
                        return _dbContext.User.Where(y => y.UserName.Contains(x)
                        || y.FullName.Contains(x)).Select(x => new UserDto
                        {
                            UserId = x.UserId,
                            FullName = x.FullName,
                            UserName = x.UserName
                        });

                    });

                    if (query != null && query.Any())
                    {
                        query.ToList().ForEach(x => result.AddRange(x));
                    }
                }
                else
                {
                    result = await _dbContext.User.Select(x => new UserDto
                    {
                        UserId = x.UserId,
                        FullName = x.FullName,
                        UserName = x.UserName
                    }).ToListAsync();
                }

                return result;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
