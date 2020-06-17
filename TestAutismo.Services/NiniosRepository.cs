using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAutismo.Models;

namespace TestAutismo.Services
{
    public class NiniosRepository:INiniosRepository
    {
        AppDBContext context;
        public NiniosRepository(AppDBContext context) 
        {
            this.context = context;
        }

        public Tutor GetNiniosbyTutor(int id)
        {
            context.Ninios.Include(x => x.CentroEducativo).ToList();
            return context.Tutores.Include(x=>x.Ninios).FirstOrDefault(x=>x.Id==id)?? new Tutor();

        }
        

        public Ninio GetNinio(int id)
        {
            return context.Ninios.Include(x => x.CentroEducativo).FirstOrDefault(x => x.Id == id);
        }

        public int InicioSesion(Cuenta cuenta)
        {
            var tutors=context.Tutores.Include(x=>x.Cuenta).ToList();
            int numero = 2;
            foreach(var item in tutors)
            {
                if (cuenta.Contraseña == item.Cuenta.Contraseña && cuenta.CorreoElectronico==item.Cuenta.CorreoElectronico)
                {
                    numero = item.Id;
                    
                }
            } 
            return numero;
        }

    }
}
