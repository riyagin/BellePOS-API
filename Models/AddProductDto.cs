using System.ComponentModel.DataAnnotations;

namespace BelleAPI.Models
{
    public class AddProductDto
    {
        [Key]
        public required string kode_item { get; set; }
        public required string nama_item { get; set; }
        public required string jenis { get; set; }
        public required string satuan { get; set; }
        public required decimal harga { get; set; }
    }
}
