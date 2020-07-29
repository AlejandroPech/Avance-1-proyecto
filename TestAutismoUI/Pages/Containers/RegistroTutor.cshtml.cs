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
    public class RegistroTutorModel : PageModel
    {
        [BindProperty]
        public Tutor NewTutor { get; set; }
        [BindProperty]
        public Cuenta Cuenta { get; set; }
        public int newtutor { get; set; }
        public readonly IRepository<Tutor> repository;
        public readonly IRepository<Cuenta> repositorycuenta;       
        
        public RegistroTutorModel(IRepository<Tutor>repository,IRepository<Cuenta> repositorycuenta)
        {
            this.repository = repository;
            this.repositorycuenta = repositorycuenta;
            
        }
        /*public void OnGet()
        {
            NewTutor = new Tutor();
            Cuenta = new Cuenta();
        }*/
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            repositorycuenta.Insert(Cuenta);
            NewTutor.Cuenta = Cuenta;
            newtutor = repository.Insert(NewTutor);
            //ViewData["newtutor"] = newtutor;
            return Redirect("/Containers/RegistroNinio?Id="+newtutor);
        }
    }
}
