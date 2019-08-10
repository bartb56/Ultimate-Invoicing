using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateInvocing.EntityFrameworkCore.Seed.Host
{
    public class DefaultTaxGroupCreater
    {
        public static List<Models.TaxGroup> InitialCountries => GetInitialCountries();
        private readonly UltimateInvocingDbContext _context;

        private static List<Models.TaxGroup> GetInitialCountries()
        {
            return new List<Models.TaxGroup>
            {
                new Models.TaxGroup(){ Name = "Low", Percentage = 9, DisplayOrder = 0, Id = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.TaxGroup(){ Name = "High", Percentage = 21, DisplayOrder = 1, Id = new Guid("00000000-0000-0000-0000-000000000002")},
            };
        }

        public DefaultTaxGroupCreater(UltimateInvocingDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCountries();
        }

        private void CreateCountries()
        {
            foreach (var taxGroup in InitialCountries)
            {
                AddTaxGroupIfNotExists(taxGroup);
            }
        }

        private void AddTaxGroupIfNotExists(Models.TaxGroup taxGroup)
        {
            if (_context.TaxGroups.Any(x => x.Name == taxGroup.Name))
                return;

            _context.TaxGroups.Add(taxGroup);
            _context.SaveChanges();
        }
    }
}
