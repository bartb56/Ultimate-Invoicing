using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UltimateInvocing.Models
{
    [Table("EmailSettings")]
    public class EmailSettings : Entity<Guid>
    {
        /// <summary>
        /// Used as the sender's email address when you don't specify a sender when sending emails 
        /// </summary>
        public string DefaultFromAddress { get; set; }

        /// <summary>
        /// Used as the sender's display name when you don't specify a sender when sending emails
        /// </summary>
        public string DefaultFromDisplayName { get; set; }

        /// <summary>
        /// The IP/Domain of the SMTP server (default: 127.0.0.1)
        /// </summary>
        public string Host { get; set; } = "127.0.0.1";

        /// <summary>
        /// The Port of the SMTP server
        /// </summary>
        public string Port { get; set; } = "25";

        /// <summary>
        /// Username, if the SMTP server requires authentication.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password, if the SMTP server requires authentication
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Domain for the username, if the SMTP server requires authentication.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// A value that indicates if the SMTP server uses SSL or not ("true" or "false". Default: "false").
        /// </summary>
        public bool EnableSsl { get; set; } = false;

        /// <summary>
        /// If true, uses default credentials instead of the provided username and password ("true" or "false". Default: "true").
        /// </summary>
        public bool UseDefaultCredentials { get; set; } = true;
    }
}
