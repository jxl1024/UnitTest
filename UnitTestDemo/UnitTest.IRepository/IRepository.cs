using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTest.IRepository
{
    public interface IRepository<T> where T:class,new()
    {
        Task<List<T>> GetList();

        Task<int?> Add(T entity);

        Task<int?> Update(T entity);

        Task<int?> Delete(T entity);
    }
}
