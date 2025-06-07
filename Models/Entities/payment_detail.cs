namespace BelleAPI.Models.Entities
{
    public class payment_detail
    {
        public int id { get; set; }
        public required string transaction_id { get; set; }
        public int payment_method { get; set; }
        public int bank_id { get; set; }
        public required decimal amount { get; set; }

    }
}
