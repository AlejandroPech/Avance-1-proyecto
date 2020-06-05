using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestAutismo.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        [Display(Name = "Correo", Prompt = "Correo")]
        public string CorreoElectronico { get; set; }
        public string NivelCuenta { get; set; }
    }
}
