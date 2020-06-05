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
        public Ninio Ninio { get; set; }

        public RegistroNinioModel(IRepositoryNinios repository)
        {
            this.repository = repository;
        }

        public void OnGet(Ninio bo)
        {
            Ninio = repository.CreateNinio(bo);
        }
    }
}
