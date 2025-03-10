using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProtocolAPI.Models;
using ProtocolAPI.Services;

namespace ProtocolAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService, MongoDbService mongoDbService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await _userService.GetUserById(id);
        return Ok(user);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAll();
        return Ok(new ApiResponse(data: users));
    }

    [HttpPost()]
    public async Task<IActionResult> AddEmployee([FromBody] User user)
    {
        try
        {
            await _userService.AddNewUser(user: user);
            return Ok(new ApiResponse(data: user));
        }
        catch (Exception e)
        {
            return BadRequest(new ApiResponse(e.Message));
        }
        
    }
}