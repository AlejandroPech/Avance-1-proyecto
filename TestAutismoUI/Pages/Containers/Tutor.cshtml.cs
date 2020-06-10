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
        public IRepositoryTutor repository;
        [BindProperty]
        public Tutor Tutor { get; private set; }
        public TutorModel(IRepositoryTutor repository)
        {
            this.repository = repository;
        }
        public void OnGet(int id)
        {
            Tutor = repository.GetTutor(id);
            ViewData["Tutor2"] = id;
        }

        public IActionResult OnPost(Tutor tutor)
        {
            Tutor = repository.UpdateTutor(tutor);
            return Page();
        }
    }
}
