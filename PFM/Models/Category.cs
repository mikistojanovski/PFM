using System.ComponentModel.DataAnnotations;

namespace PFM.Models
{
    public class Category
    {
        [Key]
        public string code { get; set; }
        public string parentcode { get; set; }
        public string name { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }

}
