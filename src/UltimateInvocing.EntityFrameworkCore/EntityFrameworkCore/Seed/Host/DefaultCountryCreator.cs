using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateInvocing.EntityFrameworkCore.Seed.Host
{
    public class DefaultCountryCreator
    {
        public static List<Models.Country> InitialCountries => GetInitialCountries();
        private readonly UltimateInvocingDbContext _context;
        
        private static List<Models.Country> GetInitialCountries()
        {
            return new List<Models.Country>
            {
                new Models.Country(){ IsoCode = "NL", IsoCode3 = "NLD", Name = "Netherlands", DisplayOrder = 0, Id = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Country(){ IsoCode = "DE", IsoCode3 = "DEU", Name = "Germany", DisplayOrder = 1, Id = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Country(){ IsoCode = "BE", IsoCode3 = "BEL", Name = "Belgium", DisplayOrder = 2, Id = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Country(){ IsoCode = "FR", IsoCode3 = "FRA", Name = "France", DisplayOrder = 3, Id = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Country(){ IsoCode = "ES", IsoCode3 = "ESP", Name = "Spain", DisplayOrder = 4, Id = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Country(){ IsoCode = "IT", IsoCode3 = "ITA", Name = "Italy", DisplayOrder = 4, Id = new Guid("00000000-0000-0000-0000-000000000005")},
            };
        }

        public DefaultCountryCreator(UltimateInvocingDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCountries();
        }

        private void CreateCountries()
        {
            foreach(var country in InitialCountries)
            {
                AddCountryIfNotExists(country);
            }
        }

        private void AddCountryIfNotExists(Models.Country country)
        {
            if (_context.Countries.Any(x => x.Name == country.Name))
                return;

            _context.Countries.Add(country);
            _context.SaveChanges();
        }
    }
}
