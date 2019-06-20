using Abp.AutoMapper;
using UltimateInvocing.Authentication.External;

namespace UltimateInvocing.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
