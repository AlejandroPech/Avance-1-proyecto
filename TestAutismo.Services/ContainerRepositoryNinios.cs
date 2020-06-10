using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public class ContainerRepositoryNinios:IRepositoryNinios
    {
        private List<Ninio> _Ninios;
        public ContainerRepositoryNinios()
        {
            _Ninios = new List<Ninio>()
            {
                new Ninio{NinioId=1,NombreNinio="Miguel",ApellidosNinio="Pech Euan",Nacionalidad=Nacionalidad.Mexicana,CurpNinio="PEPM020916HYNSRSA5",Direccion="Calle 25#80 x 6 y 8 Col. San Felipe",TutorId=1,Fotografia="Miguel.jpg",CentroEducativo=new CentroEducativo{ CentroEducativoId=1,NombreCentro="Amado Nervo",DireccionCentro="Calle 12#60 x2 y 4 Col. Los Ceibos",ClaveCentro=12345} },
                new Ninio{NinioId=2,NombreNinio="Marcos",ApellidosNinio="Perez Lopez",Nacionalidad=Nacionalidad.Mexicana,CurpNinio="MPPZ020916HYNSRSA5",Direccion="Calle 12#8 x 20 y 22 Col. San Lorenzo",TutorId=1,Fotografia=string.Empty,CentroEducativo=new CentroEducativo{ CentroEducativoId=1,NombreCentro="Amado Nervo",DireccionCentro="Calle 12#60 x2 y 4 Col. Los Ceibos",ClaveCentro=12345}},
                new Ninio{NinioId=3,NombreNinio="Marcos",ApellidosNinio="Perez Lopez",Nacionalidad=Nacionalidad.Mexicana,CurpNinio="MPPZ020916HYNSRSA5",Direccion="Calle 12#8 x 20 y 22 Col. San Lorenzo",TutorId=2,Fotografia=string.Empty,CentroEducativo=new CentroEducativo{ CentroEducativoId=1,NombreCentro="Amado Nervo",DireccionCentro="Calle 12#60 x2 y 4 Col. Los Ceibos",ClaveCentro=12345}}
            };            
        }     
        public int CreateNinio(Ninio bo)
        {

            Ninio ninio = new Ninio();
            ninio.NinioId = 4;
            ninio.Fotografia = bo.Fotografia;
            ninio.NombreNinio = bo.NombreNinio;
            ninio.ApellidosNinio = bo.ApellidosNinio;
            ninio.TutorId = 1;
            ninio.CurpNinio = bo.CurpNinio;
            ninio.Direccion = bo.Direccion;
            ninio.FechaNacimientoN = bo.FechaNacimientoN;
            ninio.CentroEducativo = bo.CentroEducativo;
            
            _Ninios.Add(ninio);
            return ninio.NinioId;
        }
        public IEnumerable<Ninio> GetNiniosbyTutor(int id)
        {
            return _Ninios.Where(x=>x.TutorId==id);
        }
        public Ninio GetNinio(int id)
        {
            return _Ninios.FirstOrDefault(x => x.NinioId == id) ?? new Ninio { CentroEducativo = new CentroEducativo() };
        }

        public Ninio UpdateNinio(Ninio ninio)
        {
            
            var Ninio = _Ninios.FirstOrDefault(x => x.NinioId == ninio.NinioId) ?? new Ninio();
            if (Ninio.NinioId == 0)
            {
                return Ninio;
            }
            //Ninio.NinioId = ninio.NinioId;
            Ninio.NombreNinio = ninio.NombreNinio;
            Ninio.ApellidosNinio = ninio.ApellidosNinio;
            Ninio.CurpNinio = ninio.CurpNinio;
            Ninio.Nacionalidad = ninio.Nacionalidad;
            Ninio.Direccion = ninio.Direccion;
            Ninio.FechaNacimientoN = ninio.FechaNacimientoN;
            Ninio.Fotografia = ninio.Fotografia;
            Ninio.TutorId = 1;
            Ninio.CentroEducativo.NombreCentro = ninio.CentroEducativo.NombreCentro;
            Ninio.CentroEducativo.ClaveCentro = ninio.CentroEducativo.ClaveCentro;
            Ninio.CentroEducativo.DireccionCentro = ninio.CentroEducativo.DireccionCentro;
            return Ninio;
        }
    }
}
