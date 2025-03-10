using MongoDB.Driver;
using ProtocolAPI.Services;

namespace ProtocolAPI.Repositories;

public interface IUserRepository
{
    public Task<User> GetById(string id);
    public Task AddNewUser(User user);
    // void Update(User user);
    public Task<IEnumerable<User>> GetAll();
    public Task<IEnumerable<User>> FindByFieldsWithOr(String? email);
}

public class UserRepository(MongoDbService mongoDbService) : IUserRepository
{
    
    public async Task<User> GetById(string id)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, id);
        return await mongoDbService.UserCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task AddNewUser(User user)
    {
        await  mongoDbService.UserCollection.InsertOneAsync(user);
    }
    public async Task<IEnumerable<User>> GetAll()
    {
        return await mongoDbService.UserCollection.Find(_ => true).ToListAsync();
    }

    public async Task<IEnumerable<User>> FindByFieldsWithOr(string? email)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Email, email);
        return await mongoDbService.UserCollection.Find(filter).ToListAsync();
    }
}