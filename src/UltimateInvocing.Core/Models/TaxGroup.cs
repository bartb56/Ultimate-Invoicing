using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UltimateInvocing.Models
{
    public class TaxGroup : Entity<Guid>
    {
        //Empty ctor
        public TaxGroup() { }

        [Required()]
        public string Name { get; set; }
        [Required()]
        public int Percentage{ get; set; }
        [Required()]
        public int DisplayOrder { get; set; }


        public virtual IList<Product> Products { get; set; }
    }
}
