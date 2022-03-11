namespace PicPaySDK.Models.Requests;

[Serializable]
public record Buyer
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("document")]
    public string Document { get; set; }
}