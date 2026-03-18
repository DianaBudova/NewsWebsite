using System;
using AutoMapper;
using NewsWebsite.Entities.Concrete;
using NewsWebsite.Entities.Dtos;

namespace NewsWebsite.Services.AutoMapper.Profiles
{
    public class NewsPostProfile : Profile
    {
        public NewsPostProfile()
        {
            CreateMap<NewsPostAddDto, NewsPost>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<NewsPostUpdateDto, NewsPost>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}