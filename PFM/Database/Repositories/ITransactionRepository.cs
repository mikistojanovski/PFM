using PFM.Database.Entities;
using PFM.Models;

namespace PFM.Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<TransactionEntity>> Create(List<TransactionEntity> Transactions);
        Task<TransactionEntity> Get(int code);
        Task<PagedSortedList<TransactionEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
        Task<TransactionEntity> CategorizeTransaction(int transactionid, string namecategory);
        Task<TransactionEntity> SplitTransaction(int transactionid);
    }
}