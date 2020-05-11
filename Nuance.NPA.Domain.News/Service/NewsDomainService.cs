using Nuance.NPA.Domain.News.Entities;
using Nuance.NPA.Domain.News.Interface.Business;
using Nuance.NPA.Domain.News.Interface.Infrastructure;
using Nuance.NPA.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nuance.NPA.Domain.News.Service
{
    public class NewsDomainService : INewsDomainService
    {
        private readonly INewsRepository _newsRepository;
        public NewsDomainService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public async Task<List<NewsEntity>> GetNewsAsync(NewsSearchDto newsDto)
        {
            NewsEntity news = new NewsEntity(newsDto);
            return await _newsRepository.GetNewsAsync(news);
        }
        public async Task<bool> PublishNewsAsync(NewsDto newsDto)
        {
            NewsEntity news = new NewsEntity(newsDto);
            return await _newsRepository.AddAsync(news);
        }
    }
}
