using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public class ContainerRepositoryTutor:IRepositoryTutor
    {
        private List<Tutor> _Tutores;
        public ContainerRepositoryTutor()
        {
            _Tutores = new List<Tutor>()
            {
                new Tutor{TutorId=1,NombreTutor="Alejandro",ApellidosTutor="Pech Paredes",CurpTutor="PEPJ010124HYNSRSA5",DireccionT="Calle 25#80 x 6 y 8 Col.San Felipe",Contraseña="12345678",NacionalidadT=Nacionalidad.Mexicana}
                
            };            
        }
        public Tutor CreateTutor(Tutor bo)
        {
            _Tutores.Add(bo);
            return new Tutor();
        }
        public IEnumerable<Tutor> GetTutors()
        {
            return _Tutores;
        }

        public Tutor GetTutor(int id)
        {
            return _Tutores.FirstOrDefault(x => x.TutorId == id);
        }
        

    }
}
