using CSI_Platform.Repository.Repository.IRepository;
using CSI_Platform.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI_Platform.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CiContext _ciContext;
        internal DbSet<T> dbset;

        public Repository(CiContext _ctx)
        {
            _ciContext = _ctx;
            dbset = _ctx.Set<T>();
        }

        public void RemoveById(int id)
        {
            T entity = dbset.Find(id);
            dbset.Remove(entity);
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetT(int id)
        {
            return dbset.Find(id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }

        public void Romove(T entity)
        {
            dbset.Remove(entity);
        }
    }
}