﻿using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using IdentityModel;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PartnerUp.EventBus.Messages.RecentEvents;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Features.Projects.Commands.CreateProject;
using PartnerUp.WorkManagement.Application.Features.Projects.Commands.DeleteProject;
using PartnerUp.WorkManagement.Application.Features.Projects.Commands.UpdateProject;
using PartnerUp.WorkManagement.Application.Features.Projects.Queries.GetProjectById;
using PartnerUp.WorkManagement.Application.Features.Projects.Queries.GetProjects;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _publishEndpoint;

    public ProjectsController(IMediator mediator, IPublishEndpoint publishEndpoint)
    {
        _mediator = mediator;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<ProjectResponse>>> GetAsync(
        [FromQuery] ProjectsParameters parameters)
    {
        var query = new GetProjectsQuery { Parameters = parameters };
        var projects = await _mediator.Send(query);
        Response.Headers.Add("X-Pagination", projects.SerializeMetadata());
        return Ok(projects);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProjectResponse>> GetByIdAsync([FromRoute] Guid id)
    {
        var query = new GetProjectByIdQuery { Id = id };
        var project = await _mediator.Send(query);

        var authorization = HttpContext.Request.Headers.Authorization;
        if (AuthenticationHeaderValue.TryParse(authorization, out var authorizationHeaderValue))
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(
                authorizationHeaderValue.Parameter);

            var userId = Guid.Parse(
                token.Claims.First(claim => claim.Type == JwtClaimTypes.Subject).Value);

            await _publishEndpoint.Publish(new ProjectAddedToRecentEvent
            {
                UserId = userId,
                ProjectId = project.Id
            });
        }

        return Ok(project);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertAsync([FromBody] CreateProjectCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateProjectCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] DeleteProjectCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}
