using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using UltimateInvocing.Company;
using UltimateInvocing.Country;
using UltimateInvocing.Province;
using UltimateInvocing.Company.Dto;
using Microsoft.AspNetCore.Hosting;

namespace UltimateInvocing.Web.Factories.Company
{
    public class CompanyFactory : ICompanyFactory
    {
        private readonly IProvinceAppService _provinceAppService;
        private readonly ICountryAppService _countryAppService;
        private readonly ICompanyAppService _companyAppService;
        private readonly IHostingEnvironment _environment;

        public CompanyFactory(IProvinceAppService provinceAppService,
            ICountryAppService countryAppService,
            ICompanyAppService companyAppService,
            IHostingEnvironment environment)
        {
            _provinceAppService = provinceAppService;
            _countryAppService = countryAppService;
            _companyAppService = companyAppService;
            _environment = environment;
        }

        public async Task<string> SetLogo(IFormFile image)
        { 
            if (CheckImage(image))
            {
                var fileName = Path.GetFileName(image.FileName);
                var path = Path.Combine(_environment.WebRootPath, "images\\companies");
                var newFileName = Guid.NewGuid() + Path.GetExtension(image.FileName);

                using (var fileStream = new FileStream(Path.Combine(path, newFileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return "images\\companies\\" + newFileName;
            }
            return "";
        }

        public bool CheckImage(IFormFile image)
        {
            //Check if the image is not null
            if (image == null || image.Length == 0)
                return false;
            //Get the file type
            var type = Path.GetExtension(image.FileName).ToUpper();
            string[] allowedTypes = new string[5] { "JPG", "PNG", "SVG", "JPEG", "GIF" };
            if (!allowedTypes.Any(type.Contains))
                return false;
            return true;
        }

        public async Task<CompanyListModel> PrepareCompanyModel()
        {
            var provinces = await _provinceAppService.GetAll();
            var countries = await _countryAppService.GetAll();
            var companies = await _companyAppService.GetAll();

            IEnumerable<SelectListItem> selectListCountry = countries.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            IEnumerable<SelectListItem> selectListProvince = provinces.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            var model = new CompanyListModel()
            {
                Provinces = selectListProvince,
                Countries = selectListCountry,
                Companies = companies
            };
            return model;
        }

        public async Task Create(CompanyDto companyDto)
        {
            companyDto.Logo = await SetLogo(companyDto.File);
            await _companyAppService.Create(companyDto);
        }


        public async Task Edit(CompanyDto companyDto)
        {
            if (companyDto.File != null)
            {
                companyDto.Logo = await SetLogo(companyDto.File);
            }


            await _companyAppService.Update(companyDto);
            return;
        }

        public async Task<CompanyListModel> PrepareEditModal(Guid id)
        {
            var company = await _companyAppService.GetById(id);
            if (company == null)
                throw new Exception("Id not found");

            var countries = await _countryAppService.GetAll();
            var provinces = await _provinceAppService.GetAllByCountryId(company.CountryId);

            IEnumerable<SelectListItem> selectListCountry = countries.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString()  }).ToList();
            IEnumerable<SelectListItem> selectListProvince = provinces.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            selectListCountry.FirstOrDefault(x => x.Value == company.CountryId.ToString()).Selected = true;
            selectListProvince.FirstOrDefault(x => x.Value == company.ProvinceId.ToString()).Selected = true;
            List<CompanyDto> companyList = new List<CompanyDto>();
            companyList.Add(company);
            var model = new CompanyListModel()
            {
                Companies = companyList,
                Countries = selectListCountry,
                Provinces = selectListProvince
            };
            
            return model;
        }
    }
}
