using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFM.Models
{
    public class Splits
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }
        
        [ForeignKey("Category")]
        public string CategoryCode { get; set; }
        public int Amount {get; set;}
        public Category Category {get; set;}
        public Transaction Transaction {get; set;}
    }
}