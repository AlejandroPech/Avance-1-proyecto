using System;
using System.Collections.Generic;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public interface IRepositoryNinios
    {
        public IEnumerable<Ninio> GetNiniosbyTutor(int id);
        public Ninio GetNinio(int id);        
        public Ninio UpdateNinio(Ninio ninio);
        public int CreateNinio(Ninio ninio);
    }
}
