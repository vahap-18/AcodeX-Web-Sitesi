using System.ComponentModel.DataAnnotations;

namespace AcodeX_Web_Sitesi.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Lütfen e-mail adresinizi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen parolanızı giriniz.")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}
