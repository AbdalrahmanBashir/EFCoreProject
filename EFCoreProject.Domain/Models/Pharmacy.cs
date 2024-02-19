namespace EFCoreProject.Domain.Models;

public partial class Pharmacy
{
    public string PharmacyName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
