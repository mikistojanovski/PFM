using PFM.Models;


namespace PFM.Services
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> Create(List<SubCategory> Categories);
       
    }
}