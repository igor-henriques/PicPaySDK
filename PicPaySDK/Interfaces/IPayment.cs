namespace PicPaySDK.Interfaces;

public interface IPayment
{
    Task<PaymentResponse> GeneratePaymentAsync(PaymentRequest request, CancellationToken cancellation = default);
    Task<PaymentCancellationResponse> CancelPaymentAsync(string referenceId, CancellationToken cancellation = default);
    Task<PaymentCancellationResponse> CancelPurchaseAsync(string referenceId, string authorizationId, CancellationToken cancellation = default);
}