using MediatR;
using Tawla._360.Application.SupplierUseCases.Dto;

namespace Tawla._360.Application.SupplierUseCases.Queries;

public record class GetAllSupplierLite:IRequest<IReadOnlyList<SupplierDto>>;
