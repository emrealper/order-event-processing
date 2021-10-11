using System;

namespace Domain.Common
{
    public class BaseAuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long Id { get; set; }
    }
}