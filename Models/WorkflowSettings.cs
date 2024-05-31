namespace scannerFakeBackend.Models;

public class WorkflowSettings : IgnoreModel
{
    public string Id { get; private set; }
    public bool Enabled { get; private set; } = default!;
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