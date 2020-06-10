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
                new Tutor{TutorId=1,NombreTutor="Alejandro",ApellidosTutor="Pech Paredes",CurpTutor="PEPJ010124HYNSRSA5",DireccionT="Calle 25#80 x 6 y 8 Col.San Felipe",Cuenta=new Cuenta{ CorreoElectronico="alejandro@gmail.com"},Contraseña="12345678",NacionalidadT=Nacionalidad.Mexicana}
                
            };            
        }
        public int CreateTutor(Tutor bo)
        {
            Tutor newtutor = new Tutor();
            newtutor.TutorId = 6;
            newtutor.NombreTutor = bo.NombreTutor;
            newtutor.ApellidosTutor = bo.ApellidosTutor;
            newtutor.Contraseña = bo.Contraseña;
            newtutor.Cuenta= bo.Cuenta;
            newtutor.CurpTutor = bo.CurpTutor;
            newtutor.DireccionT = bo.DireccionT;
            newtutor.FechaNacimientoT = bo.FechaNacimientoT;
            newtutor.NacionalidadT = bo.NacionalidadT;
            

            _Tutores.Add(newtutor);
            return newtutor.TutorId;
        }
        public IEnumerable<Tutor> GetTutors()
        {
            return _Tutores;
        }

        public Tutor GetTutor(int id)
        {
            return _Tutores.FirstOrDefault(x => x.TutorId == id);
        }
        
        public Tutor UpdateTutor(Tutor tutor)
        {
            var Tutor = _Tutores.FirstOrDefault(x => x.TutorId == tutor.TutorId)?? new Tutor();
            if (Tutor.TutorId == 0)
            {
                return Tutor;
            }
            Tutor.NombreTutor = tutor.NombreTutor;
            Tutor.ApellidosTutor = tutor.ApellidosTutor;
            Tutor.CurpTutor = tutor.CurpTutor;
            Tutor.DireccionT = tutor.DireccionT;
            Tutor.NacionalidadT = tutor.NacionalidadT;
            Tutor.FechaNacimientoT = tutor.FechaNacimientoT;
            Tutor.Cuenta.CorreoElectronico = tutor.Cuenta.CorreoElectronico;
            Tutor.Contraseña = tutor.Contraseña;
            return Tutor;
        }
    }
}
