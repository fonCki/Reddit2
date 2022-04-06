using Application.Contracts;
using Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers; 

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {

    private IUserService userService;

    public UserController(IUserService userService) {
        this.userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<User>>> GetUsers() {
        try {
            ICollection<User> users = await userService.GetUsersAsync();
            return Ok(users);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<ActionResult<User>> GetUser([FromQuery] string email) {
        try {
            User user = await userService.GetByUserAsyncByEmail(email);
            return Ok(user);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<User>> AddUser([FromBody] User user) {
        try {
            User added = await userService.AddUserAsync(user);
            return Created("added", added);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPatch]
    public async Task<ActionResult<User>> UpdateUser([FromBody] User user) {
        try {
            User updated = await userService.UpdateUserAsync(user);
            return Ok(user);
        }
        catch (Exception e) {
            return StatusCode(500, e.Message);
        }
    }

}