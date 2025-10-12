using MediatR;
using Tawla._360.Application.TaxesCases.Dtos;

namespace Tawla._360.Application.TaxesCases.Commands;

public record CreateTaxCommand(CreateTaxDto CreateTax) : INotification;
