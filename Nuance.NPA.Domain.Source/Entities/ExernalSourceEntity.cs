using Nuance.NPA.Common.Enums;
using Nuance.NPA.Domain.Source.Interface.Business;
using Nuance.NPA.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuance.NPA.Domain.Source.Entities
{
    public class ExernalSourceEntity : ISourceEntity
    {
        public int SourceID { get; set; }
        public string SourceName { get; set; }
        public string SourceURL { get; set; }
        public SourceType SourceType { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ExernalSourceEntity(SourceDto sourceDto)
        {
            SourceID = sourceDto.SourceID;
            SourceName = sourceDto.SourceName;
            SourceType = sourceDto.SourceType;
            SourceURL = sourceDto.SourceURL;
            Country = sourceDto.Country;
            State = sourceDto.State;
            City = sourceDto.City;
            SourceType = sourceDto.SourceType;
            RegistrationDate = sourceDto.RegistrationDate;
        }
    }
}
