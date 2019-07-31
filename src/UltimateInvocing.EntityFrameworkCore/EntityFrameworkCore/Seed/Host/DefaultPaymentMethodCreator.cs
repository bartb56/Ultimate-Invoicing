using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateInvocing.EntityFrameworkCore.Seed.Host
{
    public class DefaultPaymentMethodCreator
    {
        public static List<Models.PaymentType> InitialCountries => GetInitialCountries();
        private readonly UltimateInvocingDbContext _context;

        private static List<Models.PaymentType> GetInitialCountries()
        {
            return new List<Models.PaymentType>
            {
                new Models.PaymentType(){ TypeName = "Contant", DisplayOrder = 1 },
                new Models.PaymentType(){ TypeName = "Pin", DisplayOrder = 1},
                new Models.PaymentType(){ TypeName = "Credit card", DisplayOrder = 1},
                new Models.PaymentType(){ TypeName = "Tikkie", DisplayOrder = 1},
                new Models.PaymentType(){ TypeName = "PayPal", DisplayOrder = 1},
                new Models.PaymentType(){ TypeName = "Afschrijving", DisplayOrder = 1},
            };
        }

        public DefaultPaymentMethodCreator(UltimateInvocingDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCountries();
        }

        private void CreateCountries()
        {
            foreach (var country in InitialCountries)
            {
                AddCountryIfNotExists(country);
            }
        }

        private void AddCountryIfNotExists(Models.PaymentType paymentType)
        {
            if (_context.PaymentTypes.Any(x => x.TypeName == paymentType.TypeName))
                return;

            _context.PaymentTypes.Add(paymentType);
            _context.SaveChanges();
        }
    }
}
