namespace EFCoreProject.Domain.Models;

public partial class Contract
{
    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? Text { get; set; }

    public string SupervisorId { get; set; } = null!;

    public string PharmacyName { get; set; } = null!;

    public string PharmaceuticalCompanyName { get; set; } = null!;

    public virtual PharmaceuticalCompany PharmaceuticalCompanyNameNavigation { get; set; } = null!;

    public virtual Pharmacy PharmacyNameNavigation { get; set; } = null!;

    public virtual Supervisor supervisor { get; set; } = null!;
}
