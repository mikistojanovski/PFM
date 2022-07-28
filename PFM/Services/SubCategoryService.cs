using PFM.Services;
using PFM.Models;
using PFM.Database.Repositories;
using PFM.Database.Entities;

namespace PFM.Services
{
     public class SubCategoryService : ISubCategoryService
     {
         private readonly TransactionDbContext _context;
         public SubCategoryService(TransactionDbContext context)
         {
             _context = context;
         }
        

        public async Task<List<SubCategoryEntity>> Create(List<SubCategoryEntity> SubCategories)
        {
             _context.SubCategories.AddRange(SubCategories);
             await _context.SaveChangesAsync();
             return SubCategories;
        }

        public Task<List<SubCategory>> Create(List<SubCategory> Categories)
        {
            throw new NotImplementedException();
        }
    }
}