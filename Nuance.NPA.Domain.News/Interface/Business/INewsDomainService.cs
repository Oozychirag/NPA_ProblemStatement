using Nuance.NPA.Domain.News.Entities;
using Nuance.NPA.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuance.NPA.Domain.News.Interface.Business
{
    public interface INewsDomainService
    {
        Task<List<NewsEntity>> GetNewsAsync(NewsSearchDto newsDto);
        Task<bool> PublishNewsAsync(NewsDto newsDto);
    }
}
