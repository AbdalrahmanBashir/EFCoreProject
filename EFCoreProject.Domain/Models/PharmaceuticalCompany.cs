namespace EFCoreProject.Domain.Models;

public partial class PharmaceuticalCompany
{
    public string PharmaceuticalCompanyName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual IEnumerable<Contract>? Contracts { get; set; } 

    public virtual IEnumerable<Drug>? Drugs { get; set; }
}
