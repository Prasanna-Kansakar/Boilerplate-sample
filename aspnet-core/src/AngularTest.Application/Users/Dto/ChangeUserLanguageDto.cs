using System.ComponentModel.DataAnnotations;

namespace AngularTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}