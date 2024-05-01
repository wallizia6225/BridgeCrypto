using System.ComponentModel.DataAnnotations;

namespace BridgeCryptoAPI.Models
{
    public class FormData
    {
        [Required]
        public string BusinessNameOrPersonalName { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Website { get; set; }

        public string SocialProfile { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Microsoft.AspNetCore.Http.IFormFile DriverLicense { get; set; }

        [Required]
        public Microsoft.AspNetCore.Http.IFormFile SecondFileToUpload { get; set; }

        [Required]
        public Microsoft.AspNetCore.Http.IFormFile ProofOfAddress { get; set; }
    }
}
