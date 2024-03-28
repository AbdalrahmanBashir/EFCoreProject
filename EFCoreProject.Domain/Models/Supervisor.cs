namespace EFCoreProject.Domain.Models;

public partial class Supervisor
{
    public string SupervisorId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
