using PFM.Commands;
using PFM.Models;

namespace PFM.Services
{
    public interface ICategoryService
    {
        Task<List<CreateCategoryCommand>> Create(List<CreateCategoryCommand> Categories);
        Task<List<SubCategory>> Create_Sub(List<CreateCategoryCommand> Categories);
        Task<Analysis<Models.Analytics>> GetAnalysis(string catcode=null, string sd=null, string ed=null, string direction=null);
    }
}