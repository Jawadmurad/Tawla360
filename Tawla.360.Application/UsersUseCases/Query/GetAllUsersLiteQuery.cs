using MediatR;
using Tawla._360.Application.UsersUseCases.Dtos;

namespace Tawla._360.Application.UsersUseCases.Query;

public record class GetAllUsersLiteQuery:IRequest<IReadOnlyList<LiteUserDto>>;