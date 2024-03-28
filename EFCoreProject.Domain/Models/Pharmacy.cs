namespace EFCoreProject.Domain.Models;

public partial class Pharmacy
{
    public string PharmacyName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual IEnumerable<Contract>? Contracts { get; set; }

    public virtual IEnumerable<Sale>? Sales { get; set; }
}
