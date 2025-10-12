using System;

namespace Tawla._360.Domain.Exceptions;

public class BadRequestException : DomainException
{
    public BadRequestException(string message) : base(message)
    {
    }
}
