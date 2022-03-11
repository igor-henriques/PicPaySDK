namespace PicPaySDK.API;

public sealed class Notification : INotification
{
    private readonly HttpClient client;

    public Notification(string picpayToken, HttpClient client)
    {
        this.client = client;

        if (!client.DefaultRequestHeaders.Contains("x-picpay-token"))
        {
            client.DefaultRequestHeaders.Add("x-picpay-token", picpayToken);
        }
    }

    public async Task<PaymentStatus> GetPaymentStatusAsync(string referenceId, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(referenceId))
            throw new ApplicationException(new Error(HttpStatusCode.BadRequest, "referenceId não pode ser nulo ou vazio"));

        var response = await client
            .GetAsync(PicPayEndpoints.PaymentEndpoint + $"/{referenceId}/status", cancellation)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            throw new ApplicationException(new Error(response.StatusCode, await response.Content.ReadAsStringAsync()));

        return JsonSerializer.Deserialize<PaymentStatus>(await response.Content.ReadAsStringAsync());
    }
}