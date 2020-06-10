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


        public IndexModel(ILogger<IndexModel> logger,IRepositoryTutor repository)
        {
            _logger = logger;
            this.repositoriy = repository;
            
        }

        private readonly IRepositoryTutor repositoriy;
        public Tutor Tutors { get; private set; }
        
        public void OnGet(int id)
        {
            Tutors = repositoriy.GetTutor(id);
            ViewData["Panel"] = id.ToString();
        }
    }
}
