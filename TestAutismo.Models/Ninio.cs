using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TestAutismo.Models
{
    public class Ninio
    {
        public int NinioId { get; set; }
        [Display(Name = "Nombre", Prompt = "Nombre")]
        public string NombreNinio { get; set; }
        [Display(Name = "Apellidos", Prompt = "Apellidos")]
        public string ApellidosNinio { get; set; }
        public string NombreCompletoNiño { get {return $"{NombreNinio} {ApellidosNinio}".Trim(); }}
        [Display(Name = "Curp", Prompt = "Curp")]
        public string CurpNinio { get; set; }
        
        [Display(Name = "Nacionalidad", Prompt = "Nacionalidad")]
        public Nacionalidad Nacionalidad { get; set; }
        [Display(Name = "Direccion", Prompt = "Direccion")]
        public string  Direccion { get; set; }
        [Display(Name = "Fecha de Na.", Prompt = "Fecha de Na.")]
        public DateTime FechaNacimientoN { get; set; }
        public string Fotografia { get; set; }
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
        public int CentroEducativoId { get; set; }
        public CentroEducativo CentroEducativo { get; set; }
    }
}
