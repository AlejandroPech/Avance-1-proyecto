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
    public class TutorModel : PageModel
    {
        public IRepository<Tutor> repository;
        public IRepository<Cuenta> repositorycuenta;
        [BindProperty]
        public Tutor Tutor { get; set; }
        [BindProperty]
        public Cuenta Cuenta { get; set; }
        public TutorModel(IRepository<Tutor> repository,IRepository<Cuenta> repositorycuenta)
        {
            this.repository = repository;
            this.repositorycuenta = repositorycuenta;
        }
        public void OnGet(int id)
        {
            Tutor = repository.Get(id);
            Cuenta = repositorycuenta.Get(Tutor.CuentaId);
            ViewData["Tutor2"] = id;
        }

        public IActionResult OnPost()
        {
            repository.Update(Tutor);
            repositorycuenta.Update(Cuenta);
            return Redirect("/containers/tutor?id="+Tutor.Id);
        }
    }
}
