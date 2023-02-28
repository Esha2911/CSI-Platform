using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI_Platform.Repository.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetT(int id);
        void RemoveById(int id);
        void Romove(T entity);
        void Add(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
