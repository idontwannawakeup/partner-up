using MediatR;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Commands.DeleteTeam;

public class DeleteTeamCommand : IRequest
{
    public Guid Id { get; set; }
}
