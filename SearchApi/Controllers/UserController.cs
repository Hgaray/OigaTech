using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OigaTech.BusinessRules;
using OigaTech.Dto;

namespace SearchApi.Controllers
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
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _userBusinessRules.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        
        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> Search([FromBody] UserPaginatedRequest parameters)
        {
            try
            {
                return Ok(await _userBusinessRules.Search(parameters));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
