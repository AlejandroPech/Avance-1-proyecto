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
    public class ResultadosModel : PageModel
    {
        public INiniosRepository repository;
        public IEnumerable<Respuesta> respuesta { get; set; }
        public ResultadosModel(INiniosRepository repository)
        {
            this.repository = repository;
            
        }
        public void OnGet(int id)
        {
            respuesta = repository.GetRespuestasbyNinio(id);
        }

    }
}
