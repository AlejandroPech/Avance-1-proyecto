using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestAutismo.Models
{
    public class CentroEducativo:BaseEntity
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$",ErrorMessage ="El nombre debe empezar con mayusculas sin caractéres especiales")]
        [Required(ErrorMessage = "Nombre del Centro Educativo requerido")]
        [Display(Name = "Centro Edu.", Prompt = "Centro Educativo")]
        public string NombreCentro { get; set; }
        [Required(ErrorMessage = "Dirección del Centro Educativo requerido")]
        [Display(Name = "Direccion del C.E.", Prompt = "Direccion del centro educativo")]        
        public string DireccionCentro { get; set; }
        [RegularExpression("[0-9]*$", ErrorMessage = "La clave solo debe contener numeros sin espacios en blanco")]
        [Required(ErrorMessage = "Clave del Centro Educativo requerido")]
        [Display(Name = "Clave del C.E", Prompt = "Clave del centro educativo")]
        public int ClaveCentro { get; set; }
    }
}
