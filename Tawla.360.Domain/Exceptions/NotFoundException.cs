namespace Tawla._360.Domain.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException(string entityName) : base(entityName)
    {
        
    }
}
