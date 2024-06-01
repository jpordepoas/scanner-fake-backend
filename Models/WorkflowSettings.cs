using MongoDB.Bson.Serialization.Attributes;

namespace scannerFakeBackend.Models;

public class WorkflowSettings : IgnoreModel
{
    [BsonId]
    public string Id { get; private set; }
    [BsonElement("enabled")]
    public bool Enabled { get; private set; } = default!;
    [BsonElement("triggerType")]
    public string TriggerType { get; private set; }
    public WorkflowSettings(string id, bool enabled, string triggerType)
    {
        Id = id;
        Enabled = enabled;
        TriggerType = triggerType;
    }

    public void SetEnabled(bool enabled)
    {
        Enabled = enabled;
    }

    public void SetTriggerType(string triggerType)
    {
        TriggerType = triggerType;
    }
}