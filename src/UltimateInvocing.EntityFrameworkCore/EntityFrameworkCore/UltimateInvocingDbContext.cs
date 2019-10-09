using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using UltimateInvocing.Authorization.Roles;
using UltimateInvocing.Authorization.Users;
using UltimateInvocing.MultiTenancy;
using UltimateInvocing.Models;
using Abp.Configuration;

namespace UltimateInvocing.EntityFrameworkCore
{
    public class UltimateInvocingDbContext : AbpZeroDbContext<Tenant, Role, User, UltimateInvocingDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<TaxGroup> TaxGroups { get; set; }

        public DbSet<EmailSettings> EmailSettings { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }

        public UltimateInvocingDbContext(DbContextOptions<UltimateInvocingDbContext> options)
            : base(options)
        {
        }
    }
}
