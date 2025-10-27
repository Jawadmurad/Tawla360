namespace Tawla._360.Application.BranchUseCases.Dtos;

public record class LiteBranchDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Location { get; set; }
}
