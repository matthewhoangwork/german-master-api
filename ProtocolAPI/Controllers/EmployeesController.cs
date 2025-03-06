using Microsoft.AspNetCore.Mvc;
using ProtocolAPI.Services;

namespace ProtocolAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployee(int id)
    {
        var product = _employeeService.GetEmployeeGetById(id);
        return Ok(product);
    }    
    
    [HttpGet()]
    public IActionResult GetAllEmployees()
    {
        var employees = _employeeService.GetAll();
        return Ok(employees);
    }
}