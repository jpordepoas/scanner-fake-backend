using System.Text.Json.Serialization;

namespace scannerFakeBackend.Models;

public record WorkflowSettingsDto([property: JsonPropertyName("id")] string Id, 
                                    [property: JsonPropertyName("enabled")] bool Enabled, 
                                    [property: JsonPropertyName("triggerType")] string TriggerType
                                    );

public static class WorkflowSettingsDtoExtensions
{
    public static WorkflowSettingsDto? ToDto(this WorkflowSettings? settings)
    {
        if (settings is null) return null;
        return new WorkflowSettingsDto(settings.Id, settings.Enabled, settings.TriggerType);
    }
    
    public static WorkflowSettings? ToModel(this WorkflowSettingsDto? settings)
    {
        if (settings is null) return null;
        return new WorkflowSettings(settings.Id, settings.Enabled, settings.TriggerType);
    }
}