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
        public IEnumerable<Pregunta> _preguntas { get; set; }
        public CuestionarioModel(IRepositoryPreguntas repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
            _preguntas = repository.GetPreguntas();
        }
    }
}
