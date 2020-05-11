using Microsoft.EntityFrameworkCore;
using Nuance.NPA.Domain.News.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuance.NPA.Infrastructure.Persistence.News
{
   public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }
        public DbSet<NewsEntity> News { get; set; }

    }
}
