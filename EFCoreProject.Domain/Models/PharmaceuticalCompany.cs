namespace EFCoreProject.Domain.Models;

public partial class PharmaceuticalCompany
{
    public string PharmaceuticalCompanyName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Drug> Drugs { get; set; } = new List<Drug>();
}
