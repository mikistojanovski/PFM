using System.ComponentModel.DataAnnotations;

namespace PFM.Commands
{
    public class CreateCategoryCommand
    {
        [Required]
        public string code { get; set; }
        public string parentcode { get; set; }

        [Required]
        public string name { get; set; }
        
    }
}