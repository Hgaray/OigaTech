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
    }
}
