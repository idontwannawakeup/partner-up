﻿using MediatR;

namespace PartnerUp.WorkManagement.Application.Features.Projects.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest
{
    public Guid Id { get; set; }
}
