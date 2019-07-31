using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateInvocing.EntityFrameworkCore.Seed.Host
{
    public class DefaultProvinceCreator
    {
        public static List<Models.Province> InitialCountries => GetInitialProvinces();
        private readonly UltimateInvocingDbContext _context;
        
        private static List<Models.Province> GetInitialProvinces()
        {
            return new List<Models.Province>
            {
                //Dutch section
                new Models.Province(){ Name = "Groningen", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Friesland", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Drenthe", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Overijssel", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Flevoland", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Gelderland", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Utrecht", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Noord-Holland", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Zuid-Holland", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Zeeland", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Noord-Brabant", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                new Models.Province(){ Name = "Limburg", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000005")},
                //German section
                new Models.Province(){ Name = "Baden-Württemberg", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Bavaria", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Berlin", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Brandenburg", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Bremen", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Hamburg", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Hesse", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Lower Saxony", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Mecklenburg-Vorpommern", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "North Rhine-Westphalia", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Rhineland-Palatinate", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Saarland", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Saxony", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Saxony-Anhalt", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Schleswig-Holstein", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")},
                new Models.Province(){ Name = "Thuringia", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000001")}, 
                //Belgium section
                new Models.Province(){ Name = "Antwerpen", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "Oost-Vlaanderen", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "Vlaams-Brabant", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "Limburg", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "West-Vlaanderen", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "Henegouwen", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "Luik", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "Luxemburg", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "Namen", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                new Models.Province(){ Name = "Waals-Brabant", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000002")},
                //France section
                new Models.Province(){ Name = "Paris", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Bourges", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Orléans", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Rouen", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Toulouse", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Lyon", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Grenoble", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Troyes", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "La Rochelle", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Saintes", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Poitiers", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Bordeaux", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Dijon", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Amiens", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Angers", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Aix-en-Provence", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Angoulême", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Moulins", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Guéret", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Rennes", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Le Mans", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Tours", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Limoges", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Foix", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Clermont-Ferrand", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Pau", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Colmar", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Arras", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Perpignan", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Douai", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Besançon", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Metz", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Bastia", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                new Models.Province(){ Name = "Nevers", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000003")},
                //Spain section
                new Models.Province(){ Name = "Araba", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Albacete", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Alacant", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Almería", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Asturies", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Ávila", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Badajoz", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Balearic Islands", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Barcelona", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Bizkaia", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Burgos", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Cáceres", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Cádiz", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Cantabria", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Castelló", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Ciudad Real", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Córdoba", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Cuenca", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Gipuzkoa", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Girona", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Granada", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Guadalajara", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Huelva", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Huesca", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Jaén", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "La Rioja", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Las Palmas", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "León", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Lleida", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Lugo", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Madrid", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Málaga", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Murcia", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Navarre", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Ourense", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Palencia", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Pontevedra", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Salamanca", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Santa Cruz de Tenerife", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Segovia", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Seville", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Tarragona", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Teruel", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Toledo", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Valencia", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Valladolid", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Zamora", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
                new Models.Province(){ Name = "Zaragoza", DisplayOrder = 1, CountryId = new Guid("00000000-0000-0000-0000-000000000004")},
            };
        }

        public DefaultProvinceCreator(UltimateInvocingDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateProvinces();
        }

        private void CreateProvinces()
        {
            foreach(var country in InitialCountries)
            {
                AddProvinceIfNotExists(country);
            }
        }

        private void AddProvinceIfNotExists(Models.Province province)
        {
            if (_context.Provinces.Any(x => x.Name == province.Name))
                return;

            _context.Provinces.Add(province);
            _context.SaveChanges();
        }
    }
}
