using AutoMapper;
using MediatR;
using PartnerUp.Content.Application.Common.Models.Responses;
using PartnerUp.Content.Application.Interfaces.Data;

namespace PartnerUp.Content.Application.Features.Notifications.Queries.GetNotifications;

public class GetNotificationsQueryHandler
    : IRequestHandler<GetNotificationsQuery, IEnumerable<NotificationResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetNotificationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotificationResponse>> Handle(
        GetNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var notifications = await _unitOfWork.NotificationRepository.GetAsync(request.UserId);
        return _mapper.Map<IEnumerable<NotificationResponse>>(notifications);
    }
}
