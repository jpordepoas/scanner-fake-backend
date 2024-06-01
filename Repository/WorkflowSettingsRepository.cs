using MongoDB.Bson;
using MongoDB.Driver;
using scannerFakeBackend.Models;
using scannerFakeBackend.Services;

namespace scannerFakeBackend.Repositories;

public class WorkflowSettingsRepository : IWorkflowSettingsRepository
{
    private readonly string _collectionName = "WorkflowSettings";
    private readonly MongoDBService _mongo;
    private IMongoCollection<WorkflowSettings> _wfCollection => _mongo.GetCollection<WorkflowSettings>(_collectionName);


    public WorkflowSettingsRepository(MongoDBService mongo)
    {
        _mongo = mongo;
    }

    public async Task<WorkflowSettingsDto?> GetWorkflowSettingsAsync(string id)
    {
        var filter = Builders<WorkflowSettings>.Filter.Eq("_id", id);
        var settings = await _wfCollection.Find(filter).FirstOrDefaultAsync();
        return settings.ToDto();
    }

    public async Task<IEnumerable<WorkflowSettingsDto>> GetWorkflowSettingsAsync()
    {
        var result = await _wfCollection.Find(new BsonDocument()).ToListAsync();
        var settings = result is null or { Count: 0 } ? new List<WorkflowSettingsDto>() : result.Select(x => x.ToDto());
        return settings!;
    }

    public async Task CreateWorkflowSettingsAsync(WorkflowSettingsDto workflowSettings)
    {
        await _wfCollection.InsertOneAsync(workflowSettings.ToModel()!);
    }

    public async Task<bool> UpdateWorkflowSettingsAsync(string id, WorkflowSettingsDto workflowSettings)
    {
        var filter = Builders<WorkflowSettings>.Filter.Eq("_id", id);
        var result = await _wfCollection.ReplaceOneAsync(filter, workflowSettings.ToModel()!);
        return result.ModifiedCount == 1;
    }

    public async Task<bool> DeleteWorkflowSettingsAsync(string id)
    {
        var filter = Builders<WorkflowSettings>.Filter.Eq("_id", id);
        var result = await _wfCollection.DeleteOneAsync(filter);
        return result.DeletedCount == 1;
    }

    public async Task<bool> EnableWorkflowAsync(string id, bool enable)
    {
        var filter = Builders<WorkflowSettings>.Filter.Eq("_id", id);
        var update = Builders<WorkflowSettings>.Update.Set("Enabled", enable);
        var result = await _wfCollection.UpdateOneAsync(filter, update);
        return result.ModifiedCount == 1;
    }
}