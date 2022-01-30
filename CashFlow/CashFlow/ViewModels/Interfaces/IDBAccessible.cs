using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CashFlow.ViewModels.Interfaces;

namespace CashFlow.ViewModels
{
    public interface IDbAccessible<T> where T : class
    {
        public Task<int> CreateAsync(T entity);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetByPlayerIdAsync(int userId);
    }
}