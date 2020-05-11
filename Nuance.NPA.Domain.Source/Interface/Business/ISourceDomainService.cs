using Nuance.NPA.Domain.Source.Entities;
using Nuance.NPA.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuance.NPA.Domain.Source.Interface.Business
{
    public interface ISourceDomainService
    {
        Task<bool> RegistrationAsync(SourceDto sourceDto);
        Task<List<SourceEntity>> GetSoruceAsync(SourceDto sourceDto);
    }
}
