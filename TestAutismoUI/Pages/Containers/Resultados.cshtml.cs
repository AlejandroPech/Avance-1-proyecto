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
        public INiniosRepository repository;
        
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
        }


        public IActionResult OnPost()
        {
            
            return ConvertPdf(); 
        }
        public FileContentResult ConvertPdf()
        {
            //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            //Set WebKit path
            settings.WebKitPath = Path.Combine(_hostingEnvironment.ContentRootPath, "QtBinariesWindows");
            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;
            //Convert URL to PDF
            PdfDocument document = htmlConverter.Convert($"https://localhost:44302/containers/resultados/?id=" + Ninio.Id);
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, $"Resultados.pdf");
        }

        public async Task<IActionResult> OnGetAsyncGetRespuestas(int id)
        {
            var lst = await repository.AsyncGetRespuestas(id);
            return new JsonResult(lst);
        }
    }

}

