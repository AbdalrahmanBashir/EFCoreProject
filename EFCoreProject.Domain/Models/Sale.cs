namespace EFCoreProject.Domain.Models;

public partial class Sale
{
    public string DrugTradeName { get; set; } = null!;

    public string PharmacyName { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual Drug DrugTradeNameNavigation { get; set; } = null!;

    public virtual Pharmacy PharmacyNameNavigation { get; set; } = null!;
}
