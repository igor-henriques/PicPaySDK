namespace PicPaySDK.Models.Responses;

[Serializable]
public record PaymentStatus
{
    [JsonPropertyName("referenceId")]
    public string ReferenceId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("additionalInfo")]
    public List<object> AdditionalInfo { get; set; }
}