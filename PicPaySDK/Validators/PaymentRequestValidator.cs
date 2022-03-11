namespace PicPaySDK.Validators;

public static class PaymentRequestValidator
{
    public static List<string> Validate(this PaymentRequest request)
    {
        List<string> Errors = new();

        if (Errors.Any()) Errors.Clear();

        if (request is null or default(PaymentRequest)) Errors.Add("Request can't be null or default");

        if (string.IsNullOrEmpty(request?.ReferenceId)) Errors.Add("Reference ID is null");

        if (request.Value < 1) Errors.Add("Value can't be less than 1");

        if (request.ExpiresAt == default(DateTime) | request.ExpiresAt < DateTime.Now) Errors.Add("Expire time must be different from default and greater than now");

        if (request.Buyer is null or default(Buyer)) Errors.Add("Buyer can't be null or default");

        return Errors;
    }
}
