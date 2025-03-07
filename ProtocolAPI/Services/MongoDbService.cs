using MongoDB.Driver;

namespace ProtocolAPI.Services;

public class MongoDbService
{
    private readonly IMongoCollection<User> _userCollection;
    public MongoDbService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDbConnection");
        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase("dev");
        _userCollection = mongoDatabase.GetCollection<User>("Users");
    }

    public async Task<IEnumerable<User>> GetUsersASync()
    {
        return await _userCollection.Find(_ => true).ToListAsync();
    }
    public async Task AddUserAsync(User user)
    {
        await _userCollection.InsertOneAsync(user);
    }
    public async Task<User> GetUser(int id)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, id);
        return await (await _userCollection.FindAsync(filter)).FirstOrDefaultAsync();
    }
}