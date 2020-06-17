using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDBContext context;
        private DbSet<T> entities;
        public SQLRepository(AppDBContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public void Delete(T obj)
        {
            if (obj == null) throw new ArgumentNullException("Entity");

            if (obj.Id <= 0) throw new ArgumentNullException("Entity");

            obj.Update = DateTime.Now;

            var entity = entities.Attach(obj); 
            entity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public int Insert(T obj)
        {
            if (obj == null) throw new ArgumentNullException("Entity");

            context.Add(obj); 
            context.SaveChanges();
            return obj.Id;
        }

        public void Update(T obj)
        {
            if (obj == null) throw new ArgumentNullException("Entity");

            if (obj.Id <= 0) throw new ArgumentNullException("Entity");

            var entity = entities.Attach(obj); 
            entity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
