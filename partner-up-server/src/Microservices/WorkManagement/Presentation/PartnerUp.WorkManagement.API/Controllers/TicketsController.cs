using System.IdentityModel.Tokens.Jwt;
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
using PartnerUp.WorkManagement.Application.Features.Tickets.Commands.CreateTicket;
using PartnerUp.WorkManagement.Application.Features.Tickets.Commands.DeleteTicket;
using PartnerUp.WorkManagement.Application.Features.Tickets.Commands.ExtendDeadline;
using PartnerUp.WorkManagement.Application.Features.Tickets.Commands.UpdateTicket;
using PartnerUp.WorkManagement.Application.Features.Tickets.Queries.GetTicketById;
using PartnerUp.WorkManagement.Application.Features.Tickets.Queries.GetTickets;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _publishEndpoint;

    public TicketsController(IMediator mediator, IPublishEndpoint publishEndpoint)
    {
        _mediator = mediator;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedList<TicketResponse>>> GetAsync(
        [FromQuery] TicketsParameters parameters)
    {
        var query = new GetTicketsQuery { Parameters = parameters };
        var tickets = await _mediator.Send(query);
        Response.Headers.Add("X-Pagination", tickets.SerializeMetadata());
        return Ok(tickets);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TicketResponse>> GetByIdAsync([FromRoute] Guid id)
    {
        var query = new GetTicketByIdQuery { Id = id };
        var ticket = await _mediator.Send(query);

        var authorization = HttpContext.Request.Headers.Authorization;
        if (AuthenticationHeaderValue.TryParse(authorization, out var authorizationHeaderValue))
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(
                authorizationHeaderValue.Parameter);

            var userId = Guid.Parse(
                token.Claims.First(claim => claim.Type == JwtClaimTypes.Subject).Value);

            await _publishEndpoint.Publish(new TicketAddedToRecentEvent
            {
                UserId = userId,
                TicketId = ticket.Id
            });
        }

        return Ok(ticket);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertAsync([FromBody] CreateTicketCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateTicketCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("deadline")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ExtendDeadlineAsync(
        [FromBody] ExtendDeadlineCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var command = new DeleteTicketCommand { Id = id };
        await _mediator.Send(command);
        return Ok();
    }
}
