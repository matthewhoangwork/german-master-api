using ProtocolAPI.Services;

namespace ProtocolAPI.Repositories;

public interface IUserRepository
{
    public Task<User> GetById(int id);
    public Task AddNewUser(User user);
    // void Update(User user);
    public Task<IEnumerable<User>> GetAll();
}

public class UserRepository(MongoDbService mongoDbService) : IUserRepository
{
    private readonly MongoDbService _mongoDbService = mongoDbService;

    // private static List<Employee> _employees = new List<Employee>
    // {
    //     new Employee
    //     {
    //         Id = 1,
    //         Name = "John Doe",
    //     },
    //     new Employee
    //     {
    //         Id = 2,
    //         Name = "Matthew",
    //     }
    // };

    // private static int _getEmployeeIndex(int id)
    // {
    //     var employeeIndex = _employees.FindIndex(employee => employee.Id == id);
    //     if (employeeIndex == -1)
    //     {
    //         throw new Exception("Employee not found");
    //     }
    //
    //     return employeeIndex;
    // }
    //
    public async Task<User> GetById(int id)
    {
        return await _mongoDbService.GetUser(id: id);
    }

    public Task AddNewUser(User user)
    {
        return _mongoDbService.AddUserAsync(user: user);
    }

    //
    // public void Update(Employee employee)
    // {
    //     _employees[_getEmployeeIndex(employee.Id)] = employee;
    // }
    //
    public Task<IEnumerable<User>> GetAll()
    {
        return _mongoDbService.GetUsersASync();
    }
}