using MediatR;
using Tawla._360.Application.ModifierUseCases.Dto;

namespace Tawla._360.Application.ModifierUseCases.Command;

public record  CreateModifierCommand(CreateModifierDto CreateModifier):INotification;
