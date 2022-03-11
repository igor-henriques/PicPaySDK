namespace PicPaySDK.Models.Responses;

[Serializable]
public record PaymentCancellationResponse
{
    [JsonPropertyName("referenceId")]
    public string ReferenceId { get; set; }

    [JsonPropertyName("cancellationId")]
    public string CancellationId { get; set; }
}
