using Nuance.NPA.Common.Enums;
using System;

namespace Nuance.NPA.DTO
{
    public class NewsDto
    {
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
        public Guid UserId { get; set; }

    }
    public class NewsSearchDto
    {
        public NewsType NewsType { get; set; }
        public SourceType SourceType { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SortDirection { get; set; }
        public bool IsPriorityNews { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid UserId { get; set; }
    }
}
