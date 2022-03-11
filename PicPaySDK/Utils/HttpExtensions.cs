namespace PicPaySDK.Utils;

public static class HttpExtensions
{
    public static ByteArrayContent ToHttpContent<T>(this T obj)
    {
        var myContent = JsonSerializer.Serialize(obj);
        var buffer = Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);

        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return byteContent;
    }
}