using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
            int numero = 0;
            foreach(var item in tutors)
            {
                if (cuenta.Contrasenia == item.Cuenta.Contrasenia && cuenta.CorreoElectronico==item.Cuenta.CorreoElectronico)
                {
                    numero = item.Id;
                    
                }
            } 
            return numero;
        }

        public IEnumerable<Respuesta> GetRespuestasbyNinio(int id)
        {
            return context.Respuestas.Include(x => x.Pregunta).Where(x => x.NinioId == id).OrderBy(x=>x.PreguntaId);
        }

        public Respuesta GetRespuesta(int ninio, int pregunta)
        {
            IEnumerable<Respuesta> respuestas;
            respuestas=context.Respuestas.AsEnumerable();
            Respuesta respuesta = new Respuesta();
            foreach(var item in respuestas)
            {
                if (ninio == item.NinioId && pregunta == item.PreguntaId)
                {
                    respuesta = item;
                }
                else
                {
                    respuesta.NinioId = ninio;
                    respuesta.PreguntaId = pregunta;                    
                }
            }
            
            return respuesta;
        }

        public async Task<IEnumerable<Respuesta>> AsyncGetRespuestas(int id)
        {            
            return await context.Respuestas.Include(x => x.Pregunta).Where(x => x.NinioId == id).OrderBy(x=>x.PreguntaId).ToListAsync();
        }

        public int GetResultados(int id)
        {
            var respuestas = context.Respuestas.Include(x=>x.Pregunta).Where(x=>x.NinioId==id).ToList();
            int resultado = 0;
            int critica = 0;
            int normal = 0;
            foreach(var item in respuestas)
            {
                
                if (item.ValorRespuesta == false)
                {                    
                    if (item.Pregunta.Tipo == false)
                    {
                        critica = critica + 1;
                        if (critica == 2)
                        {
                            resultado = resultado + 10;
                        }
                        if (critica > 2)
                        {
                            resultado = resultado + 3;
                        }
                    }
                    if (item.Pregunta.Tipo == true)
                    {
                        normal = normal + 1;
                        critica = critica + 1;
                        if (normal == 3)
                        {
                            resultado = resultado + 10;
                        }
                        if (normal > 2)
                        {
                            resultado = resultado + 2;
                        }
                    }
                }
            }
            return resultado;
        }        
    }
}
