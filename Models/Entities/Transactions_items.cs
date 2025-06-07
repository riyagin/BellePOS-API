namespace BelleAPI.Models.Entities
{
    public class Transaction_items
    {
        public int Id { get; set; }
        public string transaction_id { get; }
        public string KodeItem { get; set; }
        public string Keterangan { get; set; }
        public int Jumlah { get; set; }
        public string Satuan { get; set; }
        public decimal Harga { get; set; }
        public double Pot { get; set; }
    }

}
