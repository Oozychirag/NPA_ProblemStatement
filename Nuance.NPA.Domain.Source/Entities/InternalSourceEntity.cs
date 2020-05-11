using Nuance.NPA.Common.Enums;
using Nuance.NPA.Domain.Source.Interface.Business;
using Nuance.NPA.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuance.NPA.Domain.Source.Entities
{
    public class InternalSourceEntity :ISourceEntity
    {
        public int SourceID { get; set; }
        public string SourceName { get; set; }
        public SourceType SourceType { get; set; }
        public DateTime RegistrationDate { get; set; }

        public InternalSourceEntity(SourceDto sourceDto)
        {
            SourceID = sourceDto.SourceID;
            SourceName = sourceDto.SourceName;
            SourceType = sourceDto.SourceType;
            RegistrationDate = sourceDto.RegistrationDate;
        }
    }
}
