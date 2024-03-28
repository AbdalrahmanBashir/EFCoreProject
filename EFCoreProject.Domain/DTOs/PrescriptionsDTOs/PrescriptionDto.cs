namespace EFCoreProject.Domain.DTOs.PrescriptionsDTOs
{
    public class PrescriptionDto
    { 

        public string DrugTradeName { get; set; } = null!;
        public DateOnly LatestDate { get; set; }
        public int Quantity { get; set; }
    }
}
