using System.Text.Json.Serialization;

namespace scannerFakeBackend.Models.Dto;

public record EnableWorkflowDto ([property: JsonPropertyName("id")] string Id, [property: JsonPropertyName("enable")] bool Enable);