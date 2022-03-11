namespace PicPaySDK.Models.Responses;

[Serializable]
public record PaymentResponse
{
    [JsonPropertyName("referenceId")]
    public string ReferenceId { get; set; }

    [JsonPropertyName("paymentUrl")]
    public string PaymentUrl { get; set; }

    [JsonPropertyName("qrcode")]
    public QrCode QrCode { get; set; }

    [JsonPropertyName("expiresAt")]
    public DateTime ExpiresAt { get; set; }
}