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
        public readonly IRepositoryNinios repository;
        public Ninio ninio { get; private set; }
        public ModificarNinioModel(IRepositoryNinios repository)
        {
            this.repository = repository;
        }
        public void OnGet(int id)
        {
            ninio = repository.GetNinio(id);
        }
    }
}
