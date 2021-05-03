using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class AddressDto
    {
        [Required]
        public string  FirstName { get; set; }
        [Required]
        public string  LastName { get; set; }
        public string  Street { get; set; }
        [Required]
        public string  City { get; set; }
        [Required]
        public string  State { get; set; }
        [Required]
        public string  PostCode { get; set; }

    }
}