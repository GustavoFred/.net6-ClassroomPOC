using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int? id);

        Task<T> Add(T obj);

        Task<T> Update(int id, T obj);

        Task<T> Delete(int id);
    }
}
