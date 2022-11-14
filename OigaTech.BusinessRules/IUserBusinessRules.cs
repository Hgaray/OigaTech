using OigaTech.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OigaTech.BusinessRules
{
    public interface IUserBusinessRules
    {
        Task<bool> Add(UserDto user);
        Task<IEnumerable<UserDto>> GetAll();
        Task<IEnumerable<UserDto>> Search(string search);
    }
}
