using Nuance.NPA.Domain.Source.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nuance.NPA.Domain.Source.Interface.Infrastructure
{
    public interface ISourceRepository
    {
        Task<bool> RegistrationAsync(SourceEntity sourceEntity);
        Task<List<SourceEntity>> GetSourceAsync(SourceEntity sourceEntity);
    }

}
