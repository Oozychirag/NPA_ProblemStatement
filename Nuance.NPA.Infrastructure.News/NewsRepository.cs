using Microsoft.EntityFrameworkCore;
using Nuance.NPA.Common.Enums;
using Nuance.NPA.Domain.News.Entities;
using Nuance.NPA.Domain.News.Interface.Infrastructure;
using Nuance.NPA.DTO;
using Nuance.NPA.Infrastructure.Persistence.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nuance.NPA.Infrastructure.News
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _context;
        private int _nextId = 1;
        public NewsRepository(NewsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
            // Add Contacts for the Demonstration
            Add(new NewsEntity(new NewsDto { Title = "News1", ContentURL = "Feeds/News/Sports/Content1URL", MediaURL = "Feeds/News/Sports/Media1URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Sports, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News2", ContentURL = "Feeds/News/Sports/Content2URL", MediaURL = "Feeds/News/Sports/Media2URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Sports, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News3", ContentURL = "Feeds/News/Political/Content1URL", MediaURL = "Feeds/News/Political/Media1URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Political, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News4", ContentURL = "Feeds/News/Political/Content2URL", MediaURL = "Feeds/News/Political/Media2URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Political, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News5", ContentURL = "Feeds/News/Travel/Content1URL", MediaURL = "Feeds/News/Travel/Media1URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Travel, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News6", ContentURL = "Feeds/News/Travel/Content2URL", MediaURL = "Feeds/News/Travel/Media2URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Travel, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News7", ContentURL = "Feeds/News/Advertisements/Content1URL", MediaURL = "Feeds/News/Advertisements/Media1URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Advertisements, IsPriorityNews = false }));
            Add(new NewsEntity(new NewsDto { Title = "News8", ContentURL = "Feeds/News/Advertisements/Content2URL", MediaURL = "Feeds/News/Advertisements/Media2URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Advertisements, IsPriorityNews = false }));

            Add(new NewsEntity(new NewsDto { Title = "News9", ContentURL = "Feeds/News/Political/Content1URL", MediaURL = "Feeds/News/Political/Media1URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Political, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News10", ContentURL = "Feeds/News/Political/Content2URL", MediaURL = "Feeds/News/Political/Media2URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Political, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News11", ContentURL = "Feeds/News/Travel/Content1URL", MediaURL = "Feeds/News/Travel/Media1URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Travel, IsPriorityNews = true }));
            Add(new NewsEntity(new NewsDto { Title = "News12", ContentURL = "Feeds/News/Travel/Content2URL", MediaURL = "Feeds/News/Travel/Media2URL", PublishDate = DateTime.Now, SourceType = SourceType.Internal, NewsType = NewsType.Travel, IsPriorityNews = true }));

        }

        /// <summary>
        /// List gettting from in - memory
        /// 4. A maximum of 8 news/items can be accommodated on a page and it should be possible to extend the number of pages
        ///5. A page can also have advertisements with the highest ratio of news/advertisement as 6/2
        /// </summary>
        public async Task<List<NewsEntity>> GetNewsAsync(NewsEntity newsEntity)
        {
            try
            {
                #region Paging initialisation
                //SortDirection not in used but for added for future implementation
                var sortDirection = string.IsNullOrEmpty(newsEntity.SortDirection) ? "ASC" : newsEntity.SortDirection;
                var skipCount = newsEntity.PageSize * (newsEntity.CurrentPage - 1);

                //Getting the News and Advertisement ratio
                var newsRatio = Math.Round((decimal)(newsEntity.PageSize * 80) / 100);
                var advRatio = Math.Round((decimal)(newsEntity.PageSize * 20) / 100);
                #endregion

                // TO DO : Code to get the list of all the news from database
                List<NewsEntity> newsPaginationList = new List<NewsEntity>();

                newsPaginationList = await _context.News.ToListAsync();
                var totalCount = newsPaginationList.Count();

                #region Page count logic
                if (skipCount >= totalCount)
                {
                    var pageCount = (totalCount % newsEntity.PageSize) == 0
                        ? ((totalCount / newsEntity.PageSize) - 1) : (totalCount / newsEntity.PageSize);
                    skipCount = totalCount < newsEntity.PageSize ? 0 : pageCount * newsEntity.PageSize;
                }
                #endregion

                //var newsPaginationList = newsList.Skip(skipCount).Take(newsEntity.PageSize).ToList();

                var isPriorityNews = newsPaginationList.Where(x => x.IsPriorityNews).Count();

                if (isPriorityNews > newsRatio)
                    newsPaginationList = newsPaginationList.Skip(skipCount).Where(x => x.NewsType != NewsType.Advertisements).Take(newsEntity.PageSize).ToList();
                else
                {
                    newsPaginationList = newsPaginationList.Skip(skipCount).Where(x => x.NewsType != NewsType.Advertisements).Take((int)newsRatio).ToList();
                    newsPaginationList = newsPaginationList.Skip(skipCount).Where(x => x.NewsType == NewsType.Advertisements).Take((int)advRatio).ToList();
                }

                return newsPaginationList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Add(NewsEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            item.NewsID = _nextId++;
            _context.News.Add(item);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// 1. Should be able to integrate news from internal and external registered source(External: Press Trust of India, Google news and Internal Sources)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(NewsEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database
            item.NewsID = _nextId++;
            _context.News.Add(item);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
