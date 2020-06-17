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
    public class ModificarNinioModel : PageModel
    {
        public IRepository<Ninio> repository;
        public IRepository<CentroEducativo> repositorycentro;
        [BindProperty]
        public Ninio Ninio { get; set; }
        [BindProperty]
        public CentroEducativo Centro { get; set; }
        public ModificarNinioModel(IRepository<Ninio> repository,IRepository<CentroEducativo>repositorycentro)
        {
            this.repository = repository;
            this.repositorycentro = repositorycentro;
        }
        public void OnGet(int id)
        {
            Ninio = repository.Get(id);

            Centro = repositorycentro.Get(Ninio.Id);
        }
        public IActionResult OnPost()
        {
            repositorycentro.Update(Centro);
            repository.Update(Ninio);
            return Redirect("/Containers/Ninios?Id="+Ninio.TutorId);            
        }
    }
}
