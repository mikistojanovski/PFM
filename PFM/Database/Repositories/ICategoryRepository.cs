using PFM.Commands;
using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Database.Repositories{



    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> Create(List<CreateCategoryCommand> Categories);
         Task<Analysis<Analytics>> GetAnalysis(string catcode=null, string startdate=null, string enddate=null, string direction=null);
       
    }
}