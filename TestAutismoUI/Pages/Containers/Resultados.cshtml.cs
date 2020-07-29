using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestAutismo.Models;
using TestAutismo.Services;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections;

namespace TestAutismoUI.Pages.Containers
{
    public class ResultadosModel : PageModel
    {        
        public int Normales { get; set; }
        public int criticas { get; set; }
        public INiniosRepository repository;
        public int resultado { get; set; }
        public IEnumerable<Respuesta> respuesta { get; set; }
        [BindProperty]
        public Ninio Ninio { get; set; }
        public IRepository<Ninio> ninio;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ResultadosModel(INiniosRepository repository,IWebHostEnvironment hostingEnvironment,IRepository<Ninio> ninio)
        {
            this.repository = repository;
            this._hostingEnvironment = hostingEnvironment;
            this.ninio = ninio;
        }
        public void OnGet(int id)
        {
            respuesta = repository.GetRespuestasbyNinio(id);
            Ninio = ninio.Get(id);
            resultado = repository.GetResultados(id);
            foreach(var item in respuesta)
            {
                if(item.ValorRespuesta==false && item.Pregunta.Tipo==false)
                {
                    criticas = criticas + 1;
                }
                if(item.ValorRespuesta==false && item.Pregunta.Tipo == true)
                {
                    Normales = Normales + 1;
                }
            }
        }


        public IActionResult OnPost()
        {            
            return ConvertPdf(); 
        }
        public FileContentResult ConvertPdf()
        {
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();            
            settings.WebKitPath = Path.Combine(_hostingEnvironment.ContentRootPath, "QtBinariesWindows");        
            htmlConverter.ConverterSettings = settings;            
            PdfDocument document = htmlConverter.Convert($"https://localhost:44302/pdf/resultadospdf/?id=" + Ninio.Id);
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, $"Resultados.pdf");
        }

        public async Task<IActionResult> OnGetAsyncGetRespuestas(int id)
        {
            List<object> list1 = new List<object>();
            
            var lst = await repository.AsyncGetRespuestas(id);
            foreach(var item in lst)
            {
                string respuesta;
                if (item.ValorRespuesta == true)
                    respuesta = "Si";
                else
                    respuesta = "No";
                    var list = new { NumPregunta = item.PreguntaId, Pregunta = item.Pregunta.PreguntaRealizada, Respuesta = respuesta };
                list1.Add(list);
            }
            return new JsonResult(list1);
        }
    }

}

