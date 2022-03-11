namespace PicPaySDK.Models.Requests;

[Serializable]
public record PaymentRequest
{
    /// <summary>
    /// Unique transaction ID
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string ReferenceId { get; set; }

    /// <summary>
    /// Callback which PicPay back-end will respond to
    /// </summary>
    [JsonPropertyName("callbackUrl")]
    public string CallbackUrl { get; set; }

    /// <summary>
    /// Transaction expiration time
    /// </summary>
    [JsonPropertyName("expiresAt")]
    public DateTime ExpiresAt { get; set; }

    [JsonPropertyName("returnUrl")]
    public string ReturnUrl { get; set; }

    /// <summary>
    /// Monetary transaction value
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }

    [JsonPropertyName("additionalInfo")]
    public List<object> AdditionalInfo { get; set; }

    /// <summary>
    /// Customer informations
    /// </summary>
    [JsonPropertyName("buyer")]
    public Buyer Buyer { get; set; }
}