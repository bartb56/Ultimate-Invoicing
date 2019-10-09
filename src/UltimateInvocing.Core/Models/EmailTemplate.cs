using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UltimateInvocing.Models
{
    [Table("EmailTemplates")]
    public class EmailTemplate : Entity<Guid>
    {
        [Required()]
        public bool IsActive { get; set; } = true;

        [Required()]
        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        [Required()]
        public string HtmlContent { get; set; }

        [Required()]
        public TemplateTypes TemplateType { get; set; }

        [Required()]
        public string Name { get; set; }

        [Required()]
        public int DisplayOrder { get; set; } = 0;
    }

    public enum TemplateTypes
    {
        Order,
        OrderReminder,
        DeliveryNote,
        ForgotPassword
    }
}
