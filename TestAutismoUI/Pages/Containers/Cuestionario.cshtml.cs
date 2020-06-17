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
        public readonly IRepository<Respuesta> repository;
        public Respuesta Respuestas { get;private set; }

        public readonly IRepository<Pregunta> preguntas;
        public Pregunta pregunta { get; set; }
        
        public CuestionarioModel(IRepository<Respuesta> repository,IRepository<Pregunta>preguntas)
        {
            this.repository = repository;
            this.preguntas = preguntas;
        }

        public void OnGet(int id)
        {
            Respuestas = new Respuesta();            
            repository.Get(id);
            Respuestas.PreguntaId = id;
            
        }


        public IActionResult OnPOst()
        {
            if (Respuestas.ValorRespuesta != null)
            {
                repository.Insert(Respuestas);
            }            

            return Page();
        }
        
    }
}
