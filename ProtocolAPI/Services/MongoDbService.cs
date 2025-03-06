using MongoDB.Driver;

namespace ProtocolAPI.Services;

public class MongoDbService
{
    private readonly IMongoCollection<Employee> _employeeCollection;
    public MongoDbService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDbConnection");
        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase("dev");
        _employeeCollection = mongoDatabase.GetCollection<Employee>("Employees");
    }

    public async Task<IEnumerable<Employee>> GetEmployeesASync()
    {
        return await _employeeCollection.Find(_ => true).ToListAsync();
    }
    public async Task AddEmployeeAsync(Employee employee)
    {
        await _employeeCollection.InsertOneAsync(employee);
    }
}