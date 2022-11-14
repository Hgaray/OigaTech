using Dapr.Client;
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
        private readonly DaprClient _daprClient;
        private const string SearchApi = "SearchApi";
        public UserController(IUserBusinessRules userBusinessRules, DaprClient daprClient)
        {
            _userBusinessRules = userBusinessRules;
            _daprClient = daprClient;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _daprClient.InvokeMethodAsync<IEnumerable<UserDto>>(
                HttpMethod.Get,
                SearchApi,
                "Api/User/GetAll");

                if (users.Any())
                {
                    return Ok(users);
                }
                else
                {
                    return NoContent();

                }
            }
            catch (Exception ex)
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
                var users = await _daprClient.InvokeMethodAsync<IEnumerable<UserDto>>(
                HttpMethod.Get,
                SearchApi,
                $"Api/User/Search?search={search}");

                if (users.Any())
                {
                    return Ok(users);
                }
                else
                {
                    return NoContent();

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
