using MediatR;
using Tawla._360.Application.AuthUseCases.Dtos;

namespace Tawla._360.Application.AuthUseCases.Queries;

public record RefreshTokenQuery(string RefreshToken):IRequest<AuthResponse>;
