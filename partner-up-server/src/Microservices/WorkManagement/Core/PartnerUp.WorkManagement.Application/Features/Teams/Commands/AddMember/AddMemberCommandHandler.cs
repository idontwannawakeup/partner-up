using MediatR;
using PartnerUp.WorkManagement.Application.Interfaces.Data;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Commands.AddMember;

public class AddMemberCommandHandler : IRequestHandler<AddMemberCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AddMemberCommand request, CancellationToken cancellationToken)
    {
        var member = new UserProfile { Id = request.UserId };
        await _unitOfWork.TeamsRepository.AddMemberAsync(request.TeamId, member);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
