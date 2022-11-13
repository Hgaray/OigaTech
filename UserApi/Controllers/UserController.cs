using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OigaTech.BusinessRules;
using OigaTech.Dto;

namespace UserWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusinessRules _userBusinessRules;
        public UserController(IUserBusinessRules userBusinessRules)
        {
            _userBusinessRules = userBusinessRules;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(1);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            if (await _userBusinessRules.Add(user))
            {
                return Ok(true);
            }
            return BadRequest("Something went wrong, UserName Could be duplicated");
        }
    }
}
