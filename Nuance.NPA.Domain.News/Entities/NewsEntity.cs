using Nuance.NPA.Common.Enums;
using Nuance.NPA.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nuance.NPA.Domain.News.Entities
{
    public class NewsEntity
    {
        [Key]
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string ContentURL { get; set; }
        public string MediaURL { get; set; }
        public NewsType NewsType { get; set; }
        public SourceType SourceType { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SortDirection { get; set; }
        public bool IsPriorityNews { get; set; }
        public Guid Userid { get; set; }

        protected NewsEntity()
        {
        }
        public NewsEntity(NewsDto newsDto)
        {
            NewsID = newsDto.NewsID;
            Title = newsDto.Title;
            ContentURL = newsDto.ContentURL;
            MediaURL = newsDto.MediaURL;
            NewsType = newsDto.NewsType;
            SourceType = newsDto.SourceType;
            PublishDate = newsDto.PublishDate;
            PageSize = newsDto.PageSize;
            CurrentPage = newsDto.CurrentPage;
            SortDirection = newsDto.SortDirection;
            IsPriorityNews = newsDto.IsPriorityNews;
            Userid = newsDto.UserId;
        }
        public NewsEntity(NewsSearchDto newsSearchDto)
        {
            NewsType = newsSearchDto.NewsType;
            SourceType = newsSearchDto.SourceType;
            PublishDate = newsSearchDto.PublishDate;
            PageSize = newsSearchDto.PageSize;
            CurrentPage = newsSearchDto.CurrentPage;
            SortDirection = newsSearchDto.SortDirection;
            IsPriorityNews = newsSearchDto.IsPriorityNews;
            Userid = newsSearchDto.UserId;
        }
    }
}
