using System.ComponentModel.DataAnnotations;

namespace UltimateInvocing.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}