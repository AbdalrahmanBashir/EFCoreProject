namespace EFCoreProject.Domain.DTOs.ContractDTOs
{
    public class ContractDto
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string? Text { get; set; }

        public string SupervisorId { get; set; } = null!;

        public string PharmacyName { get; set; } = null!;

        public string PharmaceuticalCompanyName { get; set; } = null!;

    }
}
