namespace ProtocolAPI.Repositories;

public interface IEmployeeRepository
{
    Employee GetById(int id);
    void Update(Employee product);
    IEnumerable<Employee> GetAll();
}

public class EmployeeRepository : IEmployeeRepository
{
    private static List<Employee> _employees = new List<Employee>
    {
        new Employee
        {
            Id = 1,
            Name = "John Doe",
        },
        new Employee
        {
            Id = 2,
            Name = "Matthew",
        }
    };

    private static int _getEmployeeIndex(int id)
    {
        var employeeIndex = _employees.FindIndex(employee => employee.Id == id);
        if (employeeIndex == -1)
        {
            throw new Exception("Employee not found");
        }

        return employeeIndex;
    }

    public Employee GetById(int id)
    {
        return _employees[_getEmployeeIndex(id)];
    }

    public void Update(Employee employee)
    {
        _employees[_getEmployeeIndex(employee.Id)] = employee;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _employees;
    }
}