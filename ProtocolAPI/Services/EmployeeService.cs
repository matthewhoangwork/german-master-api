using ProtocolAPI.Repositories;

namespace ProtocolAPI.Services;

public interface IEmployeeService
{
    // Employee GetEmployeeGetById(int id);
    // IEnumerable<Employee> GetAll();
    // void UpdateEmployee(Employee product);
}

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    // public Employee GetEmployeeGetById(int id)
    // {
    //     var employee = _employeeRepository.GetById(id);
    //     if (employee == null)
    //     {
    //         throw new KeyNotFoundException($"No employee found with id {id}");
    //     } 
    //     return employee;
    // }

    // public IEnumerable<Employee> GetAll()
    // {
    //     var employees = _employeeRepository.GetAll();
    //     return employees;
    // }
    //
    // public void UpdateEmployee(Employee employee)
    // {
    //     _employeeRepository.Update(employee);
    // }
}