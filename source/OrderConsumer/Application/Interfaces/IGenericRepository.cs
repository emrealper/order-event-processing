using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<T> Get(int id);
        //Task<IEnumerable<T>> GetAllAsync(int id);
        //Task<long> Add(T entity);
        //Task<int> Delete(int id);
        //Task<int> Update(T entity);
    }
}
