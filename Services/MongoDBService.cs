using MongoDB.Bson;
using MongoDB.Driver;

namespace scannerFakeBackend.Services;

public class MongoDBService
{
    private readonly MongoClient _client;
    private string DatabaseName;

    public MongoDBService(string connectionString, string dbName)
    {
        _client = new MongoClient(connectionString);
        DatabaseName = dbName;

    }

    public IMongoCollection<T> GetCollection<T>(in string collection)
    {
        var db = _client.GetDatabase(DatabaseName);
        return db.GetCollection<T>(collection);
    }

}