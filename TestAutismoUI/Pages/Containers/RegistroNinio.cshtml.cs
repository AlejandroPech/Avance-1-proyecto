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
        public readonly IRepository<Ninio> niniorepository;
        public readonly IRepository<CentroEducativo> centrorepository;
        
        [BindProperty]
        public Ninio Ninio { get; set; }
        [BindProperty]
        public CentroEducativo Centro { get;set; }
        public int NewNinio { get; set; }
        

        public RegistroNinioModel(IRepository<Ninio> niniorepository, IRepository<CentroEducativo> centrorepository)
        {
            this.niniorepository = niniorepository;
            this.centrorepository = centrorepository;
        }

        public IActionResult OnPost(int id)
        {

            Ninio.TutorId = id;
            centrorepository.Insert(Centro);
            Ninio.CentroEducativo = Centro;
            NewNinio = niniorepository.Insert(Ninio);
            return Redirect("/Containers/Ninios?Id=" + id);
        }
    }
}
