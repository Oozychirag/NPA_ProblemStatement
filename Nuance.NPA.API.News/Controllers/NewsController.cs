using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Nuance.NPA.Domain.News.Entities;
using Nuance.NPA.Domain.News.Interface.Business;
using Nuance.NPA.DTO;

namespace Nuance.NPA.API.News.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INewsDomainService _newsDomainService;
        private readonly ILogger<NewsController> _logger;
        private readonly Guid _fakeUser = Guid.NewGuid();
        public NewsController(ILogger<NewsController> logger, IMapper mapper, INewsDomainService newsDomainService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _newsDomainService = newsDomainService ?? throw new ArgumentNullException(nameof(newsDomainService));
        }

        /// <summary>
        /// Returns a news list that matches with the filtered criteria
        /// 1. Should be able to integrate news from internal and external registered source(External: Press Trust of India, Google news and Internal Sources)
        /// </summary>
        /// <param name="newsSearchDto"></param>
        /// <returns>Returns a news list that matches with the above details.</returns>
        /// <response code="200">Returns a List of the filtered news.</response>
        [Route("publish")]
        [HttpPost]
        public async Task<IActionResult> PostPublishNews(NewsDto newsDto)
        {
            newsDto.UserId = _fakeUser;
            var news = await _newsDomainService.PublishNewsAsync(newsDto);
            return Ok(news);
        }

        //[HttpGet]
        //[Route("search")]
        //public async Task<IActionResult> Get()
        //{
        //    NewsSearchDto newsSearchDto = new NewsSearchDto();
        //    newsSearchDto.PageSize = 8;
        //    newsSearchDto.CurrentPage = 1;
        //    var news = await _newsDomainService.GetNewsAsync(newsSearchDto);
        //    List<NewsDto> list = new List<NewsDto>();
        //    foreach (var item in news)
        //    {
        //        list.Add(_mapper.Map<NewsDto>(item));
        //    }
        //    return Ok(list);
        //}

        /// <summary>
        /// Returns a news list that matches with the filtered criteria
        /// 4. A maximum of 8 news/items can be accommodated on a page and it should be possible to extend the number of pages
        /// 5. A page can also have advertisements with the highest ratio of news/advertisement as 6/2
        /// 6. Advertisements can be dropped if there is no place for a high priority news item
        /// </summary>
        /// <param name="newsSearchDto"></param>
        /// <returns>Returns a news list that matches with the above details.</returns>
        /// <response code="200">Returns a List of the filtered news.</response>
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Post(NewsSearchDto newsSearchDto)
        {
            newsSearchDto.UserId = _fakeUser;
            var news = await _newsDomainService.GetNewsAsync(newsSearchDto);
            List<NewsDto> list = new List<NewsDto>();
            foreach (var item in news)
            {
                list.Add(_mapper.Map<NewsDto>(item));
            }
            return Ok(list);
        }

    }
}
