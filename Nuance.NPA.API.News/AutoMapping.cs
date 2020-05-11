using AutoMapper;
using Nuance.NPA.Domain.News.Entities;
using Nuance.NPA.DTO;

namespace Nuance.NPA.API.News
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<NewsEntity, NewsDto>();
            CreateMap<NewsSearchDto, NewsDto>();
        }
    }
}
