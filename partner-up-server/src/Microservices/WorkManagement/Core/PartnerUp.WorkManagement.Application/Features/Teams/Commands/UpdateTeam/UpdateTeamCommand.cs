﻿using MediatR;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Commands.UpdateTeam;

public class UpdateTeamCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid? LeaderId { get; set; }
    public string Name { get; set; } = default!;
    public string? Specialization { get; set; }
    public string? About { get; set; }
    public string? Avatar { get; set; }
}
