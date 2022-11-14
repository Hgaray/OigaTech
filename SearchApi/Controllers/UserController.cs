using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OigaTech.BusinessRules;

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
        
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromQuery]string search)
        {
            try
            {
                return Ok(await _userBusinessRules.Search(search));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
