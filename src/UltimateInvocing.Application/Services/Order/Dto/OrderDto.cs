using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UltimateInvocing.Company.Dto;
using UltimateInvocing.Customers;
using UltimateInvocing.Customers.Address.AddressDto;
using UltimateInvocing.Factories.Order;
using UltimateInvocing.OrderItem.Dto;
using UltimateInvocing.PaymentType.Dto;

namespace UltimateInvocing.Order.Dto
{
    [AutoMap(typeof(UltimateInvocing.Models.Order))]
    public class OrderDto : EntityDto<Guid>
    {
        public OrderDto()
        {

        }

        public OrderDto(OrderCreateModel orderCreateModel, CustomerDto customer, CompanyDto company, AdressDTO address, PaymentTypeDto paymentType)
        {
            //Order section
            Number = orderCreateModel.Number;

            //Company section
            CompanyBTW = company.BTW;
            CompanyCity = company.City;
            CompanyCountryName = company.Country.Name;
            CompanyHouseNumber = company.HouseNumber;
            CompanyIBAN = company.IBAN;
            CompanyKVK = company.KVK;
            CompanyLogo = company.Logo;
            CompanyName = company.Name;
            CompanyPhoneNumber = company.PhoneNumber;
            CompanyId = company.Id;
            CompanyPostalCode = company.PostalCode;
            CompanyProvinceName = company.Province.Name;
            CompanyStreetAddress = company.StreetAddress;

            //Customer section
            CustomerCity = address.City;
            CustomerCompanyEmail = customer.CompanyEmail;
            CustomerCompanyName = customer.CompanyName;
            CustomerCompanyPhonenumber = company.PhoneNumber;
            CustomerCountryName = address.Country.Name;
            CustomerHouseNumber = address.HouseNumber;
            CustomerPhoneNumber = address.PhoneNumber;
            CustomerPostalCode = address.PostalCode;
            CustomerProvinceName = address.Province.Name;
            CustomerStreetAddress = address.StreetAddress;
            CustomerTaxable = address.Taxable;
            CustomerId = customer.Id;
            CustomerAddressId = orderCreateModel.AddressId;


            //Payment type section
            PaymentTypeName = paymentType.TypeName;
            PaymentTypeId = paymentType.Id;
        }

        [Required()]
        public int Number { get; set; }

        #region Customer section
        public string CustomerCompanyName { get; set; }
        public string CustomerCompanyEmail { get; set; }
        public string CustomerCompanyPhonenumber { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerStreetAddress { get; set; }
        public string CustomerHouseNumber { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public bool CustomerTaxable { get; set; }
        public string CustomerCountryName { get; set; }
        public string CustomerProvinceName { get; set; }

        public Guid CustomerId { get; set; }
        #endregion

        #region Company section
        public string CompanyName { get; set; }
        public string CompanyKVK { get; set; }
        public string CompanyIBAN { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyBTW { get; set; }
        public string CompanyCountryName { get; set; }
        public string CompanyProvinceName { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyStreetAddress { get; set; }
        public string CompanyHouseNumber { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CompanyPhoneNumber { get; set; }

        public Guid CompanyId { get; set; }
        #endregion

        #region PaymentType Section
        public string PaymentTypeName { get; set; }

        public Guid PaymentTypeId { get; set; }

        public Guid CustomerAddressId { get; set; }
        #endregion

        //public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
