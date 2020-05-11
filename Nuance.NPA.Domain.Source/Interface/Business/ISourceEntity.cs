using Nuance.NPA.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuance.NPA.Domain.Source.Interface.Business
{
   public interface ISourceEntity
    {
        public int SourceID { get; set; }
        public string SourceName { get; set; }
        public SourceType SourceType { get; set; }
    }
}
