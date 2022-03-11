namespace PicPaySDK.API;

public sealed class Payment : IPayment
{
    private readonly HttpClient client;

    public Payment(string picpayToken, HttpClient client)
    {
        this.client = client;

        if (!client.DefaultRequestHeaders.Contains("x-picpay-token"))
        {
            client.DefaultRequestHeaders.Add("x-picpay-token", picpayToken);
        }
    }

    /// <summary>
    /// Generates a payment intention which returns a QrCode
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<PaymentResponse> GeneratePaymentAsync(PaymentRequest request, CancellationToken cancellation = default)
    {
        var validationResult = request.Validate();

        if (validationResult.Any())
            throw new ApplicationException(new Error(HttpStatusCode.BadRequest, validationResult));

        var response = await client
            .PostAsync(PicPayEndpoints.PaymentEndpoint, request.ToHttpContent(), cancellation)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            throw new ApplicationException(new Error(response.StatusCode, await response.Content.ReadAsStringAsync()));

        return JsonSerializer.Deserialize<PaymentResponse>(await response.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Cancel finished transactions
    /// </summary>
    /// <param name="referenceId"></param>
    /// <param name="authorizationId"></param>
    /// <returns></returns>
    /// <exception cref="ApplicationException"></exception>
    public async Task<PaymentCancellationResponse> CancelPurchaseAsync(string referenceId, string authorizationId, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(authorizationId) | string.IsNullOrEmpty(authorizationId))
            throw new ApplicationException(new Error(HttpStatusCode.BadRequest, "authorizationId or referenceId can't be null or empty"));

        var response = await client
            .PostAsync(PicPayEndpoints.PaymentEndpoint + $"{referenceId}/cancellations", authorizationId.ToHttpContent(), cancellation)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            throw new ApplicationException(new Error(response.StatusCode, await response.Content.ReadAsStringAsync()));

        return JsonSerializer.Deserialize<PaymentCancellationResponse>(await response.Content.ReadAsStringAsync());
    }

    /// <summary>
    /// Cancel pending transactions
    /// </summary>
    /// <param name="referenceId"></param>
    /// <returns></returns>
    /// <exception cref="ApplicationException"></exception>
    public async Task<PaymentCancellationResponse> CancelPaymentAsync(string referenceId, CancellationToken cancellation = default)
    {
        if (string.IsNullOrEmpty(referenceId))
            throw new ApplicationException(new Error(HttpStatusCode.BadRequest, "authorizationId can't be null or empty"));

        var response = await client
            .PostAsync(PicPayEndpoints.PaymentEndpoint + $"/{referenceId}/cancellations", null, cancellation)
            .ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            throw new ApplicationException(new Error(response.StatusCode, await response.Content.ReadAsStringAsync()));

        return JsonSerializer.Deserialize<PaymentCancellationResponse>(await response.Content.ReadAsStringAsync());
    }
}