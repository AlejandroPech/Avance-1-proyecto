using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public interface INiniosRepository
    {
        public Tutor GetNiniosbyTutor(int id);
        public Ninio GetNinio(int id);
        public IEnumerable<Respuesta> GetRespuestasbyNinio(int id);
        public int InicioSesion(Cuenta cuenta);
        public Respuesta GetRespuesta(int ninio, int pregunta);
        public Task<IEnumerable<Respuesta>> AsyncGetRespuestas(int id);
    }
}
