using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum PaymentMethodType
    {
        [Display(Name = "Paypal")] Paypal = 1,
        [Display(Name = "Invoice")] AfterPay = 2,
        [Display(Name = "OnlineBankTransfer")] OnlineBankTransfer = 3,
        [Display(Name = "CreditCard")] CreditCard = 4,
        [Display(Name = "DirectDebit")] DirectDebit = 5
    }
}