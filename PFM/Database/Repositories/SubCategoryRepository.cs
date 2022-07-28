using PFM.Database.Entities;

namespace PFM.Database.Repositories
{
     public class SubCategoryRepository : ISubCategoryRepository
     {
         private readonly TransactionDbContext _context;
         public SubCategoryRepository(TransactionDbContext context)
         {
             _context = context;
         }
        

        public async Task<List<SubCategoryEntity>> Create(List<SubCategoryEntity> SubCategories)
        {
             _context.SubCategories.AddRange(SubCategories);
             await _context.SaveChangesAsync();
             return SubCategories;
        }
    }
}