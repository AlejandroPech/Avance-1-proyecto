using System;
using System.Collections.Generic;
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
    public class ModificarNinioModel : PageModel
    {
        public IRepository<Ninio> repository;
        public IRepository<CentroEducativo> repositorycentro;
        [BindProperty]
        public Ninio Ninio { get; set; }
        [BindProperty]
        public CentroEducativo Centro { get; set; }
        public IFormFile Logo { get; set; }
        public IWebHostEnvironment HostEnviroment { get; }
        public ModificarNinioModel(IRepository<Ninio> repository,IRepository<CentroEducativo>repositorycentro, IWebHostEnvironment hostEnviroment)
        {
            this.repository = repository;
            this.repositorycentro = repositorycentro;
            this.HostEnviroment = hostEnviroment;
        }
        public void OnGet(int id)
        {
            Ninio = repository.Get(id);

            Centro = repositorycentro.Get(Ninio.Id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            if (Logo != null)
            {
                if (!string.IsNullOrEmpty(Ninio.Fotografia))
                {
                    var filePath = Path.Combine(HostEnviroment.WebRootPath, "Fotografias", Ninio.Fotografia); System.IO.File.Delete(filePath);

                }
                Ninio.Fotografia = ProcessUploadFile();
            }

            repositorycentro.Update(Centro);
            repository.Update(Ninio);
            return Redirect("/Containers/Ninios?Id="+Ninio.TutorId);            
        }

        private string ProcessUploadFile()
        {
            if (Logo == null)
                return string.Empty;

            var uploadFolder = Path.Combine(HostEnviroment.WebRootPath, "Fotografias"); var fileName = $"{Guid.NewGuid()}_{Logo.FileName}";
            var filePath = Path.Combine(uploadFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create)) { Logo.CopyTo(stream); }

            return fileName;
        }
    }
}
