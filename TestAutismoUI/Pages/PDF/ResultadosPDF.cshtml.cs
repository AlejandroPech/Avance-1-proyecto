using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestAutismo.Models;
using TestAutismo.Services;

namespace TestAutismoUI.Pages.PDF
{
    public class ResultadosPDFModel : PageModel
    {
        public int Normales { get; set; }
        public int criticas { get; set; }
        public IEnumerable<Respuesta> respuesta { get; set; }
        public INiniosRepository repository;
        public ResultadosPDFModel(INiniosRepository repository)
        {
            this.repository = repository;
        }
        public void OnGet(int id)
        {
            respuesta = repository.GetRespuestasbyNinio(id);
            foreach (var item in respuesta)
            {
                if (item.ValorRespuesta == false && item.Pregunta.Tipo == false)
                {
                    criticas = criticas + 1;
                }
                if (item.ValorRespuesta == false && item.Pregunta.Tipo == true)
                {
                    Normales = Normales + 1;
                }
            }
        }
    }
}
