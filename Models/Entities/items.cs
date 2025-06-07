namespace BelleAPI.Models.Entities
{
    public class items
    {
        public required string kode_item { get; set; }
        public required string keterangan { get; set; }
        public required string satuan { get; set; }
        public required decimal harga { get; set; }
    }
}
