using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
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

    // [HttpGet("{id}")]
    // public IActionResult GetEmployee(int id)
    // {
    //     var product = _employeeService.GetEmployeeGetById(id);
    //     return Ok(product);
    // }

    [HttpGet()]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpPost()]
    public async Task<IActionResult> AddEmployee([FromBody] User user)
    {
        await _userService.AddNewUser(user: user);
        return Ok("Success");
    }
}