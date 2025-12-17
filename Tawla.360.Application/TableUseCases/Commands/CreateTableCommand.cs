using MediatR;
using Tawla._360.Application.TableUseCases.Dtos;

namespace Tawla._360.Application.TableUseCases.Commands;

public record class CreateTableCommand(CreateTableDto CreateTable):INotification;
