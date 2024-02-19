namespace EFCoreProject.Domain.Models;

public partial class Prescription
{
    public string DoctorSsn { get; set; } = null!;

    public string PatientSsn { get; set; } = null!;

    public string DrugTradeName { get; set; } = null!;

    public DateOnly LatestDate { get; set; }

    public int Quantity { get; set; }

    public virtual Doctor DoctorSsnNavigation { get; set; } = null!;

    public virtual Drug DrugTradeNameNavigation { get; set; } = null!;

    public virtual Patient PatientSsnNavigation { get; set; } = null!;
}
