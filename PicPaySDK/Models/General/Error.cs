namespace PicPaySDK.Models.General;

public record Error
{
    public HttpStatusCode ErrorCode { get; private init; }
    public IEnumerable<string> Messages { get; private init; }

    public Error(HttpStatusCode ErrorCode, IEnumerable<string> Messages)
    {
        this.ErrorCode = ErrorCode;
        this.Messages = Messages;
    }

    public Error(HttpStatusCode ErrorCode, string message)
    {
        this.ErrorCode = ErrorCode;
        this.Messages = new List<string>() { message };
    }

    public static implicit operator string(Error error)
    {
        return $"There was an error. Status Code: {error.ErrorCode}\nMessage:{string.Join("\n", error.Messages)}";
    }
}