﻿using AutoMapper;
using MediatR;
using PartnerUp.Content.Application.Interfaces.Data;
using PartnerUp.Content.Domain.Entities;

namespace PartnerUp.Content.Application.Features.Notifications.Commands.SendNotification;

public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SendNotificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(
        SendNotificationCommand request,
        CancellationToken cancellationToken)
    {
        // ReSharper disable once UnusedVariable
        var notification = await _unitOfWork.NotificationRepository.InsertAsync(
            _mapper.Map<Notification>(request));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        // TODO: implement notification send with gRPC
        return Unit.Value;
    }
}
