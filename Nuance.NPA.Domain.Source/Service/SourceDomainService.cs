using Nuance.NPA.Common.Enums;
using Nuance.NPA.Domain.Source.Entities;
using Nuance.NPA.Domain.Source.Interface.Business;
using Nuance.NPA.Domain.Source.Interface.Infrastructure;
using Nuance.NPA.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuance.NPA.Domain.Source.Service
{
   public class SourceDomainService : ISourceDomainService
    {
        private readonly ISourceRepository _sourceRepository;
        public SourceDomainService(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }

        public async Task<List<SourceEntity>> GetSoruceAsync(SourceDto sourceDto)
        {
            SourceEntity sourceEntity = new SourceEntity(sourceDto);
            return await _sourceRepository.GetSourceAsync(sourceEntity);
        }

        public async Task<bool> RegistrationAsync(SourceDto sourceDto)
        {
            //if (sourceDto.SourceType == SourceType.External)
            //    SourceEntity _sourceRepository = new SourceEntity(sourceDto);
            //else
            //    SourceEntity registerSourceEntity = new SourceEntity(sourceDto);
            SourceEntity sourceEntity = new SourceEntity(sourceDto);
            return await _sourceRepository.RegistrationAsync(sourceEntity);
        }
    }
}
