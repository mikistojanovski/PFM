using PFM.Database.Entities;

namespace PFM.Database.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategoryEntity>> Create(List<SubCategoryEntity> Categories);       
    }
}