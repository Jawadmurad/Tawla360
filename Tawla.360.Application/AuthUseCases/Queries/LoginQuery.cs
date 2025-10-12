using MediatR;
using Tawla._360.Application.AuthUseCases.Dtos;

namespace Tawla._360.Application.AuthUseCases.Queries;

public record LoginQuery(LoginRequest LoginRequest) : IRequest<AuthResponse>;
