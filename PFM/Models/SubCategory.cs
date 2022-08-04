using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFM.Models
{
    public class SubCategory
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }

        [ForeignKey("Category")]
        public string ParentCode { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

       
    }
}
