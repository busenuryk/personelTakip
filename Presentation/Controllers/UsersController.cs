using Entities.DataTransferObject;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
        public class UsersController : ControllerBase
        {
            private readonly IServiceManager _manager;

            public UsersController(IServiceManager manager)
            {
                _manager = manager;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllUsers([FromQuery]UserParameters userParameters)
            {
                var pagedResult = await _manager.UserService.GetAllUsersAsync(userParameters, false);
                Response.Headers.Add("X-Pagination" , JsonSerializer.Serialize(pagedResult.metaData));
                
                return Ok(pagedResult.users);
            }

            [HttpGet("{id:int}")]
            public async Task<IActionResult> GetOneUserById([FromRoute(Name = "id")] int id)
            {
                var user =await _manager
                    .UserService
                    .GetOneUserByIdAsync(id, false);
                return Ok(user);
            }

            [ServiceFilter(typeof(ValidationFilterAttribute))]
            [HttpPost]
            public async Task<IActionResult> AddUser([FromBody] UserDtoForInsertion userDto)
            {
               var user = await _manager.UserService.AddOneUserAsync(userDto);
                return StatusCode(201, userDto);
            }
            [ServiceFilter(typeof(ValidationFilterAttribute))]
            [HttpPut("{id:int}")]
            public async Task<IActionResult> UpdateUserById([FromRoute(Name = "id")] int id, [FromBody] UserDtoForUpdate userDto)
            {
                await _manager.UserService.UpdateOneUserAsync(id, userDto, false);

                return NoContent();
            }

            [HttpDelete("{id:int}")]
            public async Task<IActionResult> DeleteUserById(int id)
            {
                var entity = await _manager
                    .UserService
                    .GetOneUserByIdAsync(id, false);

                await _manager.UserService.DeleteOneUserAsync(id, false);
                return NoContent();
            }
        }
}
