namespace PicPaySDK;

public class PicPayClient
{
    public readonly INotification Notification;
    public readonly IPayment Payment;

    public PicPayClient(string picpayToken, HttpClient client)
    {
        this.Notification = new Notification(picpayToken, client);
        this.Payment = new Payment(picpayToken, client);
    }
}