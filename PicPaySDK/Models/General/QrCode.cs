namespace PicPaySDK.Models.Responses;

[Serializable]
public record QrCode
{
    [JsonPropertyName("content")]
    public string Content { get; set; }

    [JsonPropertyName("base64")]
    public string Base64 { get; set; }
}