using System;
using System.Collections.Generic;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public interface IRepositoryNinios
    {
        public IEnumerable<Ninio> GetNinios();
        public Ninio GetNinio(int id);
        public Ninio CreateNinio(Ninio bo);
    }
}
