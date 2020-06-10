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
        public readonly IRepositoryPreguntas repository;
        public Pregunta _pregunta { get;private set; }
        public Ninio ninio { get; set; }
        public IEnumerable<Pregunta> _preguntas { get; private set; }
        

        
        public CuestionarioModel(IRepositoryPreguntas repository)
        {
            this.repository = repository;
        }

        public void OnGet(int id)
        {
            
            _pregunta = repository.GetPregunta(id);
            _preguntas = repository.GetPreguntas();
        }
        
    }
}
