using System;
using System.Collections.Generic;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public interface IRepositoryPreguntas
    {
        public IEnumerable<Pregunta> GetPreguntas();

        public Pregunta GetPregunta(int id);
    }
}
