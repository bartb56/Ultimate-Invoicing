using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateInvocing.Models
{
    public class Tax : Entity<Guid>
    {
        public string Name { get; set; }
        public int Percentage { get; set; }
        public int DisplayOrder { get; set; }

    }
}
