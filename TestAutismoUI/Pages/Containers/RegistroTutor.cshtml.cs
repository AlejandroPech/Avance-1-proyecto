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
        public Tutor NewTutor { get; set; }
        private readonly IRepositoryTutor repositoriy;
        
        public RegistroTutorModel(IRepositoryTutor repository)
        {
            this.repositoriy = repository;
        }
        public void OnGet(Tutor bo)
        {
            NewTutor = repositoriy.CreateTutor(bo);
        }
    }
}
