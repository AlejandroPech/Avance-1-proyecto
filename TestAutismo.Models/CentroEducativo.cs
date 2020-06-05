using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestAutismo.Models
{
    public class CentroEducativo
    {
        public int CentroEducativoId { get; set; }
        [Display(Name = "Centro Edu.", Prompt = "Centro Educativo")]
        public string NombreCentro { get; set; }
        [Display(Name = "Direccion del C.E.", Prompt = "Direccion del centro educativo")]
        public string DireccionCentro { get; set; }
        [Display(Name = "Clave del C.E", Prompt = "Clave del centro educativo")]
        public int ClaveCentro { get; set; }
    }
}
