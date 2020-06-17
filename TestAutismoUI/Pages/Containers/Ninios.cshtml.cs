using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestAutismo.Models;
using TestAutismo.Services;

namespace TestAutismoUI.Pages.Containers
{
    public class NiniosModel : PageModel
    {
        private readonly INiniosRepository repository;

        public Tutor Ninios { get; private set; }    
                        
        public NiniosModel(INiniosRepository repository)
        {
            this.repository = repository;
        }
        public void OnGet(int id) 
        {
            Ninios = repository.GetNiniosbyTutor(id);
            ViewData["Tutor"] = id;
        }
    }
}
