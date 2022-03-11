namespace PicPaySDK.Interfaces;
public interface INotification
{
    Task<PaymentStatus> GetPaymentStatusAsync(string referenceId, CancellationToken cancellation = default);
}