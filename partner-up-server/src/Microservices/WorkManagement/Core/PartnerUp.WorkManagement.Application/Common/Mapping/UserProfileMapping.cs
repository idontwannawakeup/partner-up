﻿using AutoMapper;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Common.Mapping;

public class UserProfileMapping : Profile
{
    public UserProfileMapping()
    {
        CreateMap<UserProfile, UserResponse>()
            .ForMember(
                response => response.FullName,
                options => options.MapFrom(user => $"{user.FirstName} {user.LastName}"))
            .ForMember(
                response => response.Avatar,
                options => options.MapFrom(user => !string.IsNullOrWhiteSpace(user.Avatar)
                    ? $"IdentityService/Public/Photos/{user.Avatar}"
                    : null));
    }
}
