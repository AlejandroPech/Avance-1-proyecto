using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestAutismo.Models;
using TestAutismo.Services;

namespace TestAutismoUI.Pages.Containers
{
    public class RegistroNinioModel : PageModel
    {
        public readonly IRepository<Ninio> niniorepository;
        public readonly IRepository<CentroEducativo> centrorepository;
        
        [BindProperty]
        public Ninio Ninio { get; set; }
        [BindProperty]
        public CentroEducativo Centro { get;set; }
        public int NewNinio { get; set; }
        
        public IFormFile Logo { get; set; }        
        public IWebHostEnvironment HostEnviroment { get; }
        public RegistroNinioModel(IRepository<Ninio> niniorepository, IRepository<CentroEducativo> centrorepository, IWebHostEnvironment hostEnviroment)
        {
            this.niniorepository = niniorepository;
            this.centrorepository = centrorepository;
            this.HostEnviroment = hostEnviroment;
        }
        public void OnGet(int id)
        {
            Ninio = new Ninio();
            Ninio.TutorId = id;
            Ninio.FechaNacimientoN = DateTime.Now;
        }
        public IActionResult OnPost()
        {            
            if (!ModelState.IsValid)
                return Page();
            if (Logo != null)
            {
                if (!string.IsNullOrEmpty(Ninio.Fotografia))
                {
                    var filePath = Path.Combine(HostEnviroment.WebRootPath, "images", Ninio.Fotografia); 
                    System.IO.File.Delete(filePath);

                }
               Ninio.Fotografia = ProcessUploadFile();
            }           

            centrorepository.Insert(Centro);            
            Ninio.CentroEducativo = Centro;
            NewNinio = niniorepository.Insert(Ninio);
            
            return Redirect("/Containers/Ninios?Id=" + Ninio.TutorId);
        }

        private string ProcessUploadFile()
        {
            if (Logo == null) 
                return string.Empty;

            var uploadFolder = Path.Combine(HostEnviroment.WebRootPath, "Fotografias"); 
            var fileName = $"{Guid.NewGuid()}_{Logo.FileName}";
            var filePath = Path.Combine(uploadFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create)) { Logo.CopyTo(stream); }

            return fileName;
        }
    }
}
