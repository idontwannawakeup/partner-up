using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Requests;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Responses;
using PartnerUp.Identity.People.BusinessLogic.Interfaces;
using PartnerUp.Identity.People.BusinessLogic.Interfaces.Services;
using PartnerUp.Identity.Persistence.People.Data.Entities;
using PartnerUp.Identity.Persistence.People.Interfaces.Data;
using PartnerUp.Identity.Persistence.People.Interfaces.Data.Repositories;
using PartnerUp.Shared.Exceptions;

namespace PartnerUp.Identity.People.BusinessLogic.Services;

public class IdentityService : IIdentityService
{
    private readonly IMapper _mapper;
    private readonly IJwtSecurityTokenFactory _tokenFactory;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUsersRepository _usersRepository;
    private readonly UserManager<User> _userManager;

    public IdentityService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IJwtSecurityTokenFactory tokenFactory,
        UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _tokenFactory = tokenFactory;
        _usersRepository = _unitOfWork.UsersRepository;
        _userManager = userManager;
    }

    public async Task<JwtResponse> SignInAsync(UserSignInRequest request)
    {
        var user = await _usersRepository.FindByNameOrThrowAsync(request.UserName);

        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new EntityNotFoundException("Incorrect username or password.");
        }

        var jwtToken = _tokenFactory.BuildToken(user);
        return new JwtResponse { Token = SerializeToken(jwtToken), UserId = user.Id };
    }

    public async Task<JwtResponse> SignUpAsync(UserSignUpRequest request)
    {
        var user = _mapper.Map<UserSignUpRequest, User>(request);
        var signUpResult = await _userManager.CreateAsync(user, request.Password);

        if (!signUpResult.Succeeded)
        {
            var errors = string.Join(
                Environment.NewLine,
                signUpResult.Errors.Select(error => error.Description));

            throw new ArgumentException(errors);
        }

        await _unitOfWork.SaveChangesAsync();

        var jwtToken = _tokenFactory.BuildToken(user);
        return new JwtResponse { UserId = user.Id, Token = SerializeToken(jwtToken) };
    }

    private static string SerializeToken(JwtSecurityToken jwtToken) =>
        new JwtSecurityTokenHandler().WriteToken(jwtToken);
}
