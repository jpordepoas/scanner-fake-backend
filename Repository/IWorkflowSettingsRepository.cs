using MongoDB.Bson;
using scannerFakeBackend.Models;

namespace scannerFakeBackend.Repositories;

public interface IWorkflowSettingsRepository
{
    Task<WorkflowSettingsDto?> GetWorkflowSettingsAsync(string id);
    Task<IEnumerable<WorkflowSettingsDto>> GetWorkflowSettingsAsync();
    Task CreateWorkflowSettingsAsync(WorkflowSettingsDto workflowSettings);
    Task<bool> UpdateWorkflowSettingsAsync(string id, WorkflowSettingsDto workflowSettings);
    Task<bool> DeleteWorkflowSettingsAsync(string id);
    Task<bool> EnableWorkflowAsync(string id, bool enable);
}