using MediatR;
using Microsoft.AspNetCore.Http;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Commands.SetTeamAvatar;

public class SetTeamAvatarCommand : IRequest
{
    public Guid TeamId { get; set; }
    public IFormFile Avatar { get; set; } = default!;
}
