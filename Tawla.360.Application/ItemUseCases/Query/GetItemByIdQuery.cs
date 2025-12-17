using MediatR;
using Tawla._360.Application.ItemUseCases.Dtos;

namespace Tawla._360.Application.ItemUseCases.Query;

public record class GetItemByIdQuery(Guid Id):IRequest<ItemDto>;
