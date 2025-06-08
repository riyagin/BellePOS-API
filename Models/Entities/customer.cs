using System.ComponentModel.DataAnnotations;

namespace BelleAPI.Models.Entities
{
    public class customer
    {
        [Key]
        public required string id { get; set; }

        [Required]
        public required string name { get; set; }

        public string phone { get; set; }

        public string? address { get; set; }

        public string? NIK { get; set; }

        public DateTime? tgl_lahir { get; set; }
    }
}
