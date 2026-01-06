using System;
using MediatR;

namespace Tawla._360.Application.TableUseCases.Commands;

public record DeleteTableCommand(Guid Id):INotification;
