using MediatR;
using Tawla._360.Application.SurchargeUseCase.Dto;

namespace Tawla._360.Application.SurchargeUseCase.Queries;

public record GetAllSurchargesLiteQuery : IRequest<IReadOnlyList<SurchargeLiteDto>>;
