using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestAutismo.Models
{
    public class Cuenta:BaseEntity
    {
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage ="Este correo electrónico es invalido")]
        [Required(ErrorMessage ="El Correo Electronico es requerido")]
        [Display(Name = "Correo", Prompt = "Correo")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "Contraseña requerida")]
        public string Contrasenia { get; set; }
    }
}
