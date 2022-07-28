namespace PFM.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public string beneficiaryname { get; set; }
        public DateTime date { get; set; }
        public string direction { get; set; }
        public double amount { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public int? mcc { get; set; }
        public string kind { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
