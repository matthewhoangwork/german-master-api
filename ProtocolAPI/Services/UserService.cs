using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Bson;
using ProtocolAPI.Repositories;

namespace ProtocolAPI.Services;

public interface IUserService
{
    Task<User> GetUserById(string id);
    Task AddNewUser(User user);

    Task<IEnumerable<User>> GetAll();
    // void UpdateEmployee(Employee product);
}

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User> GetUserById(string id)
    {
        var user = await userRepository.GetById(id);
        return user;
    }
    


    private async Task<bool> _IsValidNewUserUniqueFields(User newUser)
    {
        var users = await userRepository.FindByFieldsWithOr(email: newUser.Email);
        if (users.Where((user) => user.Email == newUser.Email).ToList().Count == 0)
        {
            return true;
        }

        return false;
    }

    public async Task AddNewUser(User user)
    {
        if (await _IsValidNewUserUniqueFields(user))
        {
            await userRepository.AddNewUser(new User
            {
                Name = user.Name,
                Id = ObjectId.GenerateNewId().ToString(),
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
        var employees = userRepository.GetAll();
        return employees;
    }
    //
    // public void UpdateEmployee(Employee employee)
    // {
    //     _employeeRepository.Update(employee);
    // }
}