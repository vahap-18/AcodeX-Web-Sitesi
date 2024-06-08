using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AcodeX_Web_Sitesi.Models
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen ad soyad giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen parolanızı giriniz")]
        public string Password { get; set; }

        [Display(Name = "Parola tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz")]
        public string Email { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }

    }
}
