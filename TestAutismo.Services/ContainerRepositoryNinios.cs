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
                new Ninio{NinioId=2,NombreNinio="Marcos",ApellidosNinio="Perez Lopez",Nacionalidad=Nacionalidad.Mexicana,CurpNinio="MPPZ020916HYNSRSA5",Direccion="Calle 12#8 x 20 y 22 Col. San Lorenzo",TutorId=1,Fotografia=string.Empty,CentroEducativo=new CentroEducativo{ CentroEducativoId=1,NombreCentro="Amado Nervo",DireccionCentro="Calle 12#60 x2 y 4 Col. Los Ceibos",ClaveCentro=12345}}

            };
        }     
        public Ninio CreateNinio(Ninio bo)
        {            
            return new Ninio();
        }
        public IEnumerable<Ninio> GetNinios()
        {
            return _Ninios;
        }
        public Ninio GetNinio(int id)
        {
            return _Ninios.FirstOrDefault(x => x.NinioId == id) ?? new Ninio { CentroEducativo = new CentroEducativo() };
        }

    }
}
