using System;
using System.Collections.Generic;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public interface IRepositoryTutor
    {
        public IEnumerable<Tutor> GetTutors();
        public Tutor GetTutor(int id);
        public int CreateTutor(Tutor bo);
        public Tutor UpdateTutor(Tutor tutor);
        
    }
}
