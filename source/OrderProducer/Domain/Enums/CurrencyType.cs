using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CurrencyType
    {
        [Display(Name = "EURO")] Euro = 1,
        [Display(Name = "USD")] Usd = 2,
        [Display(Name = "GBP")] Gbp = 3
    }
}