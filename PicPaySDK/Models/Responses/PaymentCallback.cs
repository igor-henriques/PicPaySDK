namespace PicPaySDK.Models.Responses;

[Serializable]
public record PaymentCallback
{
    [JsonPropertyName("referenceId")]
    public string ReferenceId { get; set; }

    [JsonPropertyName("authorizationId")]
    public string AuthorizationId { get; set; }
}