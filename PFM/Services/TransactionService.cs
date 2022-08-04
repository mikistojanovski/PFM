using System.Transactions;
using AutoMapper;
using PFM.Commands;
using PFM.Database.Entities;
using PFM.Database.Repositories;
using PFM.Models;
using PFM.Services;

namespace PFM.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;

        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Models.Transaction> CategorizeTransaction(int transactionid, string namecategory)
        {
            var result = await _transactionRepository.CategorizeTransaction(transactionid, namecategory);

            return _mapper.Map<Models.Transaction>(result);
        }

        public async Task<List<Models.Transaction>> CreateTransaction(List<CreateTransactionCommand> command)
        {
            var entity = _mapper.Map<List<TransactionEntity>>(command);
            var result = await _transactionRepository.Create(entity);

            return _mapper.Map<List<Models.Transaction>>(result);
        }

        public async Task<Models.Transaction> Get(int Code)
        {
            var transaction = await _transactionRepository.Get(Code);

            if (transaction == null)
            {
                return null;
            }

            return _mapper.Map<Models.Transaction>(transaction);
        }

        public async Task<PagedSortedList<Models.Transaction>> GetTransactions(int page = 1, int pageSize = 5, string sortBy = null, Models.SortOrder sortOrder = Models.SortOrder.Asc)
        {
            var result = await _transactionRepository.List(page, pageSize, sortBy, sortOrder);

            return _mapper.Map<PagedSortedList<Models.Transaction>>(result);
        }

        public async Task<Models.Transaction> SplitTransactions(int transactionid)
        {
            var transaction = await _transactionRepository.SplitTransaction(transactionid);

            if (transaction == null)
            {
                return null;
            }

            return _mapper.Map<Models.Transaction>(transaction);
        }
    }
}