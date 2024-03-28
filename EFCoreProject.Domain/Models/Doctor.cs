namespace EFCoreProject.Domain.Models;

public partial class Doctor
{
    public string PersonSsn { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Speciality { get; set; } = null!;

    public int ExperienceYears { get; set; }

    public virtual IEnumerable<Patient>? Patients { get; set; }

    public virtual IEnumerable<Prescription>? Prescriptions { get; set; }
}
