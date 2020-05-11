using Microsoft.EntityFrameworkCore;
using Nuance.NPA.Common.Enums;
using Nuance.NPA.Domain.Source.Entities;
using Nuance.NPA.Domain.Source.Interface.Infrastructure;
using Nuance.NPA.DTO;
using Nuance.NPA.Infrastructure.Source.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nuance.NPA.Infrastructure.Source
{
    public class SourceRepository : ISourceRepository
    {
        private readonly SourceContext _context;
        private int _nextId = 1;
        public SourceRepository(SourceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //Mock registered new sources to get new content
            RegistrationAsync(new SourceEntity(new SourceDto { SourceName = "Press Trust of India", SourceURL = "https://www.presstrustofindia.com", RegistrationDate = DateTime.Now, SourceType = SourceType.External, IsActive = true }));
            RegistrationAsync(new SourceEntity(new SourceDto { SourceName = "Google news", SourceURL = "https://www.googlenews.com", RegistrationDate = DateTime.Now, SourceType = SourceType.External, IsActive = true }));
            RegistrationAsync(new SourceEntity(new SourceDto { SourceName = "Internal Sources", SourceURL = "https://www.npaindia.com", RegistrationDate = DateTime.Now, SourceType = SourceType.Internal, IsActive = true }));
        }
        public async Task<List<SourceEntity>> GetSourceAsync(SourceEntity sourceEntity)
        {
            List<SourceEntity> sourceList = new List<SourceEntity>();
            try
            {
                // TO DO : Code to get the list of all the source from database
                sourceList = await _context.Source.ToListAsync();
                sourceList = sourceList.Where(x => x.IsActive == true).ToList();
            }
            catch (Exception EX)
            {
                throw;
            }
            return sourceList;
        }

        public async Task<bool> RegistrationAsync(SourceEntity sourceEntity)
        {
            if (sourceEntity == null)
            {
                throw new ArgumentNullException("Registration");
            }

            // TO DO : Code to save record into database
            sourceEntity.SourceID = _nextId++;
            _context.Add(sourceEntity);
            _context.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}
