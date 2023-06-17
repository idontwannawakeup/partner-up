using AutoMapper;
using PartnerUp.Social.BusinessLogic.Common.Models.Requests;
using PartnerUp.Social.BusinessLogic.Common.Models.Responses;
using PartnerUp.Social.DataAccess.Data.Entities;

namespace PartnerUp.Social.BusinessLogic.Common.Mapping;

public class RatingMapping : Profile
{
    public RatingMapping()
    {
        CreateMap<RatingRequest, Rating>();
        CreateMap<Rating, RatingResponse>()
            .ForMember(response => response.Average,
                options => options.MapFrom(
                    rating => (rating.Skills
                               + rating.Social
                               + rating.Punctuality
                               + rating.Responsibility) / 4));
    }
}
