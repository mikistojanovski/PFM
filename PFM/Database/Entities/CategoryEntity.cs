using System.ComponentModel.DataAnnotations;

namespace PFM.Database.Entities
{
    public class CategoryEntity
    {
       
        [Key]
        public string code { get; set; }
        public string parentcode { get; set; }        
        public string name { get; set; }
        public ICollection<SubCategoryEntity> SubCategories { get; set; }
    }
}