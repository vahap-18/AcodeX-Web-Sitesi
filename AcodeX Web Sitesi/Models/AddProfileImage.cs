namespace AcodeX_Web_Sitesi.Models
{
    public class AddProfileImage
    {
        public int WriterId { get; set; }
        public required string Name { get; set; }
        public string? Surname { get; set; }
        public required string Email { get; set; }
        public string? FieldOfInterest { get; set; }
        public bool? Sex { get; set; }
        public string? About { get; set; }
        public IFormFile? Image { get; set; }
        public string? Country { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? GitHub { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? LinkedIn { get; set; }
        public string? Tweeter { get; set; }
        public string? Website { get; set; }
        public string? KnowTeknologies { get; set; }
        public string? ProgrammingLanguages { get; set; }
        public required string Password { get; set; }
        public required bool Status { get; set; }
    }
}
