using MediatR;
using Tawla._360.Application.TaxesCases.Dtos;

namespace Tawla._360.Application.TaxesCases.Queries;

public class GetAllTaxesLiteQuery:IRequest<IReadOnlyList<TaxLiteDto>>;
