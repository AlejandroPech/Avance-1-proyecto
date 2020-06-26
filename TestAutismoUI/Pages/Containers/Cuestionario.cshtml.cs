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
        public IEnumerable<Respuesta> respuestas { get; set; }
        [BindProperty]
        public string Respuesta1 { get; set; }
        public string[] Respuestas = new[] { "Si", "No" }; 
        [BindProperty]
        public string preguntarealizada { get; set; }
        [BindProperty]
        public int numero { get; set; }        
        public readonly IRepository<Respuesta> repository;
        [BindProperty]
        public Respuesta Respuesta { get; set; }
        public readonly IRepository<Pregunta> preguntas; 
        [BindProperty]
        public Pregunta pregunta { get; set; }        
        
        public CuestionarioModel(IRepository<Respuesta> repository,IRepository<Pregunta>preguntas)
        {
            this.repository = repository;
            this.preguntas = preguntas;            
        }

        public void OnGet(int id,int Pregunta)
        {            
            Respuesta = new Respuesta();
            
            pregunta = preguntas.Get(Pregunta);
            respuestas = repository.GetAll();
            Respuesta.PreguntaId = Pregunta;
            Respuesta.NinioId = id;
        }
        public IActionResult OnPost()
        {
            if (Respuesta1 == "Si")
            {
                Respuesta.ValorRespuesta = true;
            }
            else if (Respuesta1 == "No")
            {
                Respuesta.ValorRespuesta = false;
            }
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
            if (preguntarealizada == "mas")
            {
                numero = pregunta.Id + 1;
            }
            else if (preguntarealizada == "menos")
            {
                numero = pregunta.Id + -1;
            }
            else if(preguntarealizada== "guardar")
            {
                return Redirect("/containers/modificarninio/?id=" + Respuesta.NinioId);
            }
            else if (preguntarealizada == "terminar")
            {
                return Redirect("/containers/resultados/?id=" + Respuesta.NinioId);
            }                                           

            return Redirect("/containers/cuestionario/?id="+Respuesta.NinioId+"&Pregunta="+numero);
        }
        
    }
}
