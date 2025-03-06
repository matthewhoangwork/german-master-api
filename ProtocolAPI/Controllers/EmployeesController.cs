using Microsoft.AspNetCore.Mvc;
using ProtocolAPI.Services;

namespace ProtocolAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly MongoDbService _mongoDbService;

    public EmployeesController(IEmployeeService employeeService, MongoDbService mongoDbService)
    {
        _employeeService = employeeService;
        _mongoDbService = mongoDbService;
    }

    // [HttpGet("{id}")]
    // public IActionResult GetEmployee(int id)
    // {
    //     var product = _employeeService.GetEmployeeGetById(id);
    //     return Ok(product);
    // }

    [HttpGet()]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _mongoDbService.GetEmployeesASync();
        return Ok(employees);
    }

    [HttpPost()]
    public async Task<IActionResult> AddEmployee()
    {
        await _mongoDbService.AddEmployeeAsync(employee: new Employee{Name = "Ngọc"});
        return Ok("Success");
    }
}