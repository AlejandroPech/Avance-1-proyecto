using System;
using System.Collections.Generic;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public interface IRepository<T>where T:BaseEntity
    {
        public IEnumerable<T> GetAll();
        public T Get(int id); 
        public int Insert(T obj);
        public void Update(T obj);
        public void Delete(T obj);
    }
}
