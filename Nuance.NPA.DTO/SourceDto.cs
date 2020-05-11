using Nuance.NPA.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuance.NPA.DTO
{
    public class SourceDto
    {
        public int SourceID { get; set; }
        public string SourceName { get; set; }
        public string SourceURL { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public SourceType SourceType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
