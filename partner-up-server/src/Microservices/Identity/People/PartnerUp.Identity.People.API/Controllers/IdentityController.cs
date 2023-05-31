using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PartnerUp.EventBus.Messages;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Requests;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Responses;
using PartnerUp.Identity.People.BusinessLogic.Interfaces.Services;

namespace PartnerUp.Identity.People.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public IdentityController(
        IIdentityService identityService,
        IPublishEndpoint publishEndpoint,
        IMapper mapper)
    {
        _identityService = identityService;
        _publishEndpoint = publishEndpoint;
        _mapper = mapper;
    }

    [HttpPost("signIn")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<JwtResponse>> SignInAsync([FromBody] UserSignInRequest request)
    {
        var response = await _identityService.SignInAsync(request);
        return Ok(response);
    }

    [HttpPost("signUp")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<JwtResponse>> SignUpAsync([FromBody] UserSignUpRequest request)
    {
        var response = await _identityService.SignUpAsync(request);
        var eventMessage = _mapper.Map<UserCreatedEvent>(request);
        eventMessage.Id = response.UserId;
        await _publishEndpoint.Publish(eventMessage);
        return Ok(response);
    }
}
