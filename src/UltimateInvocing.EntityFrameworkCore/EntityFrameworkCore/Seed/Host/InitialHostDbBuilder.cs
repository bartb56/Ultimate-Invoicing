using System.Linq;

namespace UltimateInvocing.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly UltimateInvocingDbContext _context;

        public InitialHostDbBuilder(UltimateInvocingDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();


            if(!_context.Countries.Any())
                new DefaultCountryCreator(_context).Create();
            if(!_context.Provinces.Any())
                new DefaultProvinceCreator(_context).Create();
            _context.SaveChanges();
            if (!_context.PaymentTypes.Any())
                new DefaultPaymentMethodCreator(_context).Create();
            if (!_context.TaxGroups.Any())
                new DefaultTaxGroupCreater(_context).Create();
        }
    }
}
