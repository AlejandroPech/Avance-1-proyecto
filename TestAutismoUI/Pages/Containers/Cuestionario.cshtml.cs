using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestAutismo.Models;
using TestAutismo.Services;

namespace TestAutismoUI.Pages.Containers
{
    public class CuestionarioModel : PageModel
    {        
        [BindProperty]
        public int numero { get; set; }        
        public readonly IRepository<Respuesta> repository;
        [BindProperty]
        public Respuesta Respuesta { get; set; }
        public readonly IRepository<Pregunta> preguntas; 
        [BindProperty]
        public Pregunta pregunta { get; set; }        
        public IEnumerable<Pregunta> Preguntas { get; set; }
        public INiniosRepository niniosRepository;
        public CuestionarioModel(IRepository<Respuesta> repository,IRepository<Pregunta>preguntas,INiniosRepository niniosRepository)
        {
            this.repository = repository;
            this.preguntas = preguntas;
            this.niniosRepository = niniosRepository;
        }

        public void OnGet(int id,int Pregunta)
        {
            Respuesta = niniosRepository.GetRespuesta(id, Pregunta);
            Preguntas=preguntas.GetAll();
            pregunta = preguntas.Get(Pregunta);            
        }
        public IActionResult OnPost()
        {            
            if (Respuesta.ValorRespuesta != null)
            {
                if (Respuesta.Id >= 1)
                {
                    repository.Update(Respuesta);
                }
                else
                {
                    repository.Insert(Respuesta);
                }
            }
            
            if(numero==0)
            {
                return Redirect("/containers/modificarninio/?id=" + Respuesta.NinioId);
            }
            else if (numero==24)
            {
                return Redirect("/containers/resultados/?id=" + Respuesta.NinioId);
            }                                           

            return Redirect("/containers/cuestionario/?id="+Respuesta.NinioId+"&Pregunta="+numero);
        }
        
    }
}
