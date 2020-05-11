using Nuance.NPA.Domain.News.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuance.NPA.Domain.News.Interface.Infrastructure
{
    public interface INewsRepository
    {
        Task<List<NewsEntity>> GetNewsAsync(NewsEntity newsEntity);
        Task<bool> AddAsync(NewsEntity newsEntity);
    }
}
