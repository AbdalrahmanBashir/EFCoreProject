namespace EFCoreProject.Domain.Models;

public partial class Drug
{
    public string DrugTradeName { get; set; } = null!;

    public string Formula { get; set; } = null!;

    public string PharmaceuticalCompanyName { get; set; } = null!;

    public virtual PharmaceuticalCompany PharmaceuticalCompanyNameNavigation { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
