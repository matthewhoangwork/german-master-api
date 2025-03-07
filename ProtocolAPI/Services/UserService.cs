using Microsoft.AspNetCore.Mvc.Filters;
using ProtocolAPI.Repositories;

namespace ProtocolAPI.Services;

public interface IUserService
{
    // Task<User> GetUserGetById(int id);
    Task AddNewUser(User user);
    Task<IEnumerable<User>> GetAll();
    // void UpdateEmployee(Employee product);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // public User GetUserGetById(int id)
    // {
    //     var employee = _userRepository.GetById(id);
    //     if (employee == null)
    //     {
    //         throw new KeyNotFoundException($"No employee found with id {id}");
    //     } 
    //     return employee;
    // }

    // public Task<User> GetUserGetById(int id)
    // {
    //     throw new NotImplementedException();
    // }


    private async Task<bool> IsValidNewUser(User newUser)
    {
        var users = await _userRepository.GetAll();
        if (users.Where((user) => user.Email == newUser.Email).ToList().Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public async Task AddNewUser(User user)
    {
        if (await IsValidNewUser(user))
        {
            await _userRepository.AddNewUser(new User
            {
                Name = user.Name,
                Id = user.Id,
                CreatedDate = DateTime.Now,
                Email = user.Email
            });
        }
        else
        {
            throw new Exception($"User {user.Email} already exists.");
        }
    }

    public Task<IEnumerable<User>> GetAll()
    {
        var employees = _userRepository.GetAll();
        return employees;
    }
    //
    // public void UpdateEmployee(Employee employee)
    // {
    //     _employeeRepository.Update(employee);
    // }
}