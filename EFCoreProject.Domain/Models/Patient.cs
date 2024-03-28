namespace EFCoreProject.Domain.Models;

public partial class Patient
{
    public string PersonSsn { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? Age { get; set; }

    public string? DoctorSsn { get; set; }

    public virtual Doctor? DoctorSsnNavigation { get; set; }

    public virtual IEnumerable<Prescription>? Prescriptions { get; set; }
}
