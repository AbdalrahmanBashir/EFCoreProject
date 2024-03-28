namespace EFCoreProject.Domain.Models;

public partial class Drug
{
    public string DrugTradeName { get; set; } = null!;

    public string Formula { get; set; } = null!;

    public string PharmaceuticalCompanyName { get; set; } = null!;

    public virtual PharmaceuticalCompany PharmaceuticalCompanyNameNavigation { get; set; } = null!;

    public virtual IEnumerable<Prescription>? Prescriptions { get; set; }

    public virtual IEnumerable<Sale>? Sales { get; set; }
}
