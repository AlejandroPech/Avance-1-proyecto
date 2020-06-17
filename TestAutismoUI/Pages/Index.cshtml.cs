using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TestAutismo.Models;
using TestAutismo.Services;

namespace TestAutismoUI.Pages
{
    public class IndexModel : PageModel
    {
       
        
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Cuenta Cuenta { get; set; }      
        
        public INiniosRepository repository;
        public int numero;

        public IndexModel(ILogger<IndexModel> logger,INiniosRepository repository)
        {
            _logger = logger;
            this.repository = repository;            
        }          
        public IActionResult OnPost()
        {
            numero = repository.InicioSesion(Cuenta);
            //int id;

            return Redirect("/Containers/Ninios?Id=" +numero);
            //ViewData["Panel"] = id.ToString();            
        }
    }
}
