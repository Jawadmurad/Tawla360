namespace Tawla._360.Application.BranchUseCases.Dtos;

public record class BranchListDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Location { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}
