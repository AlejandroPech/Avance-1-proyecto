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
    public class RegistroNinioModel : PageModel
    {
        public readonly IRepositoryNinios repository;
        [BindProperty]
        public Ninio Ninio { get; set; }
        public int NewNinio { get; set; }
        public int TutorId { get; set; }

        public RegistroNinioModel(IRepositoryNinios repository)
        {
            this.repository = repository;
        }

        public IActionResult OnPost(int id)
        {
            
            NewNinio = repository.CreateNinio(Ninio);
            return Redirect("/Containers/Ninios?Id=" + id);
        }
    }
}
