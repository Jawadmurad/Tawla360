using MediatR;
using Tawla._360.Application.SupplierUseCases.Dto;

namespace Tawla._360.Application.SupplierUseCases.Commands;

public record class UpdateSupplierCommand(UpdateSupplierDto UpdateSupplier):INotification;