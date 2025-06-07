namespace BelleAPI.Models.Entities
{
    public class Transactions
    {
        public string Id { get; set; }
        public DateTime timestamp { get; set; }
        public string customer_id { get; set; }
        public decimal tax { get; set; }
        public decimal discount { get; set; }
        public decimal total_amount { get; set; }

    }
}
