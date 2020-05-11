using AutoMapper;
using Nuance.NPA.Domain.News.Entities;
using Nuance.NPA.Domain.Source.Entities;
using Nuance.NPA.DTO;
namespace Nuance.NPA.API.Source
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SourceEntity, SourceDto>();
        }
    }
}
