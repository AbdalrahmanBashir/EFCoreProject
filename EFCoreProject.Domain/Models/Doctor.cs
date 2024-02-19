namespace EFCoreProject.Domain.Models;

public partial class Doctor
{
    public string PersonSsn { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Speciality { get; set; } = null!;

    public int ExperienceYears { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
