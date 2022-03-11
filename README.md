# PicPaySDK

<p align="center">
  <img src="https://i.imgur.com/UHsNCKK.png" />
</p>

<p align="center">A .NET 6 PicPay Integration</p>

# How to use

* Preparing

First, get your "x_picpay_token" token here https://painel-empresas.picpay.com/integracoes and store it appropriately on your project.</br>
Then instantiate PicPayClient, which needs your token above and a HttpClient. Examples:
``` C#
private readonly PicPayClient client;

public class Foo()
{
    this.client = new PicPayClient(secrets.Value.Token, client);
}
```

If you are working with dependency injection, is possible to inject a HttpClient to a service class, like:
``` C#
builder.Services.AddHttpClient<PicPayService>();
```

``` C#
public class PicPayService : IPicPayService
{
    private readonly PicPayClient client;
    private readonly ILogger<PicPayService> logger;

    public PicPayService(IOptions<PicPaySecrets> secrets, HttpClient client, ILogger<PicPayService> logger)
    {
        this.client = new PicPayClient(secrets.Value.Token, client);
        this.logger = logger;
    }
}
```

* Consuming

To get a payment request:
``` C#
public async Task<PaymentResponse> CreatePaymentRequestAsync(PaymentRequest request)
{
    return await client.Payment.GeneratePaymentAsync(request);
}
```

Checking request status:
``` C#
public async Task<PaymentStatus> GetPaymentStatusAsync(string referenceId)
{
    return await client.Notification.GetPaymentStatusAsync(referenceId);
}
```

Cancelling requests:
``` C#
public async Task<PaymentCancellationResponse> CancelPaymentAsync(string referenceId)
{
    return await client.Payment.CancelPaymentAsync(referenceId);
}

public async Task<PaymentCancellationResponse> CancelPurchaseAsync(string referenceId, string authorizationId)
{
    return await client.Payment.CancelPurchaseAsync(referenceId, authorizationId);
}
```
Tip: All methods allows CancellationToken as overload
